namespace CS220C.Tests

open CS220

open System
open Microsoft.VisualStudio.TestTools.UnitTesting

module Utils =
  let tap f x = f x; x

module TestHelper =
  let tPredicate _ = true

  let fPredicate _ = false

  let mkRegForm id pw name email =
    { RegistrationID = id
      RegistrationPassword = pw
      RegistrationName = name
      RegistrationEmail = email }

  let getEntry x =
    Assert.IsTrue (Option.isSome x)
    Option.get x

  let getDBEntries db = UserDB.select db tPredicate

  let checkEntriesEqual a b =
    Assert.IsTrue (List.length a = List.length b)
    Assert.IsTrue (Set.ofList a = Set.ofList b)

  let isDBValid a =
    let l = UserDB.select a tPredicate
    Assert.AreEqual (List.length l, Set.ofList l |> Set.count)

  let checkDBEqual a b =
    (UserDB.select a tPredicate, UserDB.select b tPredicate)
    ||> checkEntriesEqual

  let getNth i x =
    Assert.IsTrue (List.isEmpty x |> not)
    List.item i x

  let assertSome x = Assert.IsTrue (Option.isSome x)

  let assertNone x = Assert.IsTrue (Option.isNone x)

  let entryOfForm f =
    WebServer.translateRegisterForm f |> getEntry

open Utils
open TestHelper

[<TestClass>]
type TestClass () =
    let i = ref 0
    /// Helpers for futher tests
    member __.MakeHugeDB size =
      let initializer _ =
        i := !i + 1
        mkRegForm (sprintf "U%d" !i) "tP1!" "tN" "t@t.t"
        |> WebServer.translateRegisterForm |> getEntry
      let foldAux (i, acc) elem =
        (i + 1UL, UserDB.insert acc elem)
        |> tap (fun (i, e) -> Assert.AreEqual (i, UserDB.length e |> uint64))
      Array.init size initializer
      |> Array.fold foldAux (0UL, UserDB.empty) |> snd

    member __.GetEntry () =
      UserDB.select (__.MakeHugeDB 1) tPredicate |> getNth 0

    member __.BuildDB i =
       Array.init i
         (fun i -> mkRegForm (sprintf "user%d" i) "Pw1!" "person" "p@test.com")
       |> Array.fold WebServer.processRegistrationRequest UserDB.empty
       |> tap (fun db -> Assert.AreEqual (uint64 i, UserDB.length db |> uint64))

    member __.VerifyRegistration forms =
      let entries = Array.map entryOfForm forms
      Array.fold WebServer.processRegistrationRequest UserDB.empty forms
      |> getDBEntries
      |> checkEntriesEqual (List.ofArray entries)

    /// Register tests
    /// Total: 10pts
    [<DataTestMethod;Timeout(10000)>]
    [<DataRow(1)>]
    [<DataRow(10)>]
    [<DataRow(20)>]
    [<DataRow(50)>]
    [<DataRow(100)>]
    [<DataRow(500)>]
    member __.``Valid registration test`` sz =
      Array.init sz
        (fun i -> mkRegForm (sprintf "user%d" i) "Pw1!" "person" "p@test.com")
      |> __.VerifyRegistration

    [<TestMethod;Timeout(10000)>]
    member __.``Invalid registration test 1`` () =
      let db =
        [| mkRegForm "user1" "Pw1!" "person" "person@example.com"
           mkRegForm "user1" "Pw2!" "person2" "persontwo@example.com" |]
        |> Array.fold WebServer.processRegistrationRequest UserDB.empty
      Assert.AreEqual (1UL, UserDB.length db |> uint64)

    [<TestMethod;Timeout(10000)>]
    member __.``Invalid registration test 2`` () =
      let db =
        [| mkRegForm "user1" "Pw1!" "person" "person@example.com"
           mkRegForm "user2" "Pw2" "person2" "persontwo@example.com" |]
        |> Array.fold WebServer.processRegistrationRequest UserDB.empty
      Assert.AreEqual (1UL, UserDB.length db |> uint64)

    [<TestMethod;Timeout(10000)>]
    member __.``Invalid registration test 3`` () =
      let db =
        [| mkRegForm "user1" "Pw1!" "person" "person@example.com"
           mkRegForm "user2" "Pw2!" "person2" "person2@example.com" |]
        |> Array.fold WebServer.processRegistrationRequest UserDB.empty
      Assert.AreEqual (1UL, UserDB.length db |> uint64)


    /// Update tests
    /// Total: 10pts
    [<TestMethod;Timeout(10000)>]
    member __.``Valid webserver update test 1``() =
      let db = __.BuildDB 50
      let ndb = { OldID = "user42"; OldPassword = "Pw1!"
                  NewID = Some "master"; NewPassword = None
                  NewName = None; NewEmail = None }
                |> WebServer.processUpdateRequest db
      let entry = mkRegForm "user42" "Pw1!" "person" "p@test.com" |> entryOfForm
      let nentry =
        mkRegForm "master" "Pw1!" "person" "p@test.com" |> entryOfForm
      isDBValid ndb
      Assert.AreEqual (50UL, UserDB.length ndb |> uint64)
      Assert.IsTrue (getDBEntries ndb
                     |> List.filter (fun i  -> i = entry)
                     |> List.isEmpty)
      Assert.AreEqual (1, getDBEntries ndb
                          |> List.filter (fun i -> i = nentry)
                          |> List.length)
    [<TestMethod;Timeout(10000)>]
    member __.``Valid webserver update test 2``() =
      let db = __.BuildDB 50
      let ndb = { OldID = "user42"; OldPassword = "Pw1!"
                  NewID = None; NewPassword = Some "Pw2!"
                  NewName = None; NewEmail = None }
                |> WebServer.processUpdateRequest db
      let entry = mkRegForm "user42" "Pw1!" "person" "p@test.com" |> entryOfForm
      let nentry =
        mkRegForm "user42" "Pw2!" "person" "p@test.com" |> entryOfForm
      isDBValid ndb
      Assert.AreEqual (50UL, UserDB.length ndb |> uint64)
      Assert.IsTrue (getDBEntries ndb
                     |> List.filter (fun i  -> i = entry)
                     |> List.isEmpty)
      Assert.AreEqual (1, getDBEntries ndb
                          |> List.filter (fun i -> i = nentry)
                          |> List.length)
    [<TestMethod;Timeout(10000)>]
    member __.``Valid webserver update test 3``() =
      let db = __.BuildDB 50
      let ndb = { OldID = "user42"; OldPassword = "Pw1!"
                  NewID = None; NewPassword = None
                  NewName = Some "person2"; NewEmail = None }
                |> WebServer.processUpdateRequest db
      let entry = mkRegForm "user42" "Pw1!" "person" "p@test.com" |> entryOfForm
      let nentry =
        mkRegForm "user42" "Pw1!" "person2" "p@test.com" |> entryOfForm
      isDBValid ndb
      Assert.AreEqual (50UL, UserDB.length ndb |> uint64)
      Assert.IsTrue (getDBEntries ndb
                     |> List.filter (fun i  -> i = entry)
                     |> List.isEmpty)
      Assert.AreEqual (1, getDBEntries ndb
                          |> List.filter (fun i -> i = nentry)
                          |> List.length)

    [<TestMethod;Timeout(10000)>]
    member __.``Valid webserver update test 4``() =
      let db = __.BuildDB 50
      let ndb = { OldID = "user42"; OldPassword = "Pw1!"
                  NewID = Some "master"; NewPassword = Some "Pw2!"
                  NewName = Some "person2"; NewEmail = Some "n@test.com" }
                |> WebServer.processUpdateRequest db
      let entry = mkRegForm "user42" "Pw1!" "person" "p@test.com" |> entryOfForm
      let nentry =
        mkRegForm "master" "Pw2!" "person2" "n@test.com" |> entryOfForm
      Assert.AreEqual (50UL, UserDB.length db |> uint64)
      Assert.IsTrue (getDBEntries ndb
                     |> List.filter (fun i -> i = entry)
                     |> List.isEmpty)
      Assert.AreEqual (1, getDBEntries ndb
                          |> List.filter (fun i -> i = nentry)
                          |> List.length)

    [<TestMethod;Timeout(10000)>]
    member __.``Invalid webserver update test 1``() =
      /// XXX: ID not exists
      let db = __.BuildDB 50
      let ndb = { OldID = "user4242"; OldPassword = "Pw1!"
                  NewID = Some "master"; NewPassword = None
                  NewName = None; NewEmail = None }
                |> WebServer.processUpdateRequest db
      isDBValid ndb
      checkDBEqual ndb db
    [<TestMethod;Timeout(10000)>]
    member __.``Invalid webserver update test 2``() =
      /// XXX: password mismatch
      let db = __.BuildDB 50
      let ndb = { OldID = "user42"; OldPassword = "Pw42!"
                  NewID = Some "master"; NewPassword = None
                  NewName = None; NewEmail = None }
                |> WebServer.processUpdateRequest db
      isDBValid ndb
      checkDBEqual ndb db
    [<TestMethod;Timeout(10000)>]
    member __.``Invalid webserver update test 3``() =
      // XXX: Invalid UserID
      let db = __.BuildDB 50
      let ndb = { OldID = "user42"; OldPassword = "Pw1!"
                  NewID = Some (String.replicate 40 "a"); NewPassword = None
                  NewName = None; NewEmail = None }
                |> WebServer.processUpdateRequest db
      isDBValid ndb
      checkDBEqual ndb db
    [<TestMethod;Timeout(10000)>]
    member __.``Invalid webserver update test 4``() =
      // XXX: Invalid Password
      let db = __.BuildDB 50
      let ndb = { OldID = "user42"; OldPassword = "Pw1!"
                  NewID = None; NewPassword = Some "pw"
                  NewName = None; NewEmail = None }
                |> WebServer.processUpdateRequest db
      isDBValid ndb
      checkDBEqual ndb db
    [<TestMethod;Timeout(10000)>]
    member __.``Invalid webserver update test 5``() =
      // XXX: Invalid UserName
      let db = __.BuildDB 50
      let ndb = { OldID = "user42"; OldPassword = "Pw1!"
                  NewID = None; NewPassword = None
                  NewName = Some (String.replicate 40 "a"); NewEmail = None }
                |> WebServer.processUpdateRequest db
      isDBValid ndb
      checkDBEqual ndb db
    [<TestMethod;Timeout(10000)>]
    member __.``Invalid webserver update test 6``() =
      /// XXX: Invalid EMail
      let db = __.BuildDB 50
      let ndb = { OldID = "user42"; OldPassword = "Pw1!"
                  NewID = None; NewPassword = None
                  NewName = None; NewEmail = Some "#!#!" }
                |> WebServer.processUpdateRequest db
      isDBValid ndb
      checkDBEqual ndb db

    /// deregister tests
    /// Total: 5pts
    [<TestMethod;Timeout(10000)>]
    member __.``Valid webserver deregistration test 1`` () =
      let db = __.BuildDB 1
      let form = { DeregisterID = "user0"; DeregisterPassword = "Pw1!" }
      Assert.AreEqual (0UL, WebServer.processDeregistrationRequest db form
                            |> UserDB.length |> uint64)

    [<TestMethod;Timeout(10000)>]
    member __.``Valid webserver deregistration test 2`` () =
      let db = __.BuildDB 50
      let form = { DeregisterID = "user42"; DeregisterPassword = "Pw1!" }
      Assert.AreEqual (49UL, WebServer.processDeregistrationRequest db form
                             |> UserDB.length |> uint64)
    [<TestMethod;Timeout(10000)>]
    member __.``Valid webserver deregistration test 3`` () =
      let db = __.BuildDB 50
      let folder acc i =
        { DeregisterID = sprintf "user%d" i; DeregisterPassword = "Pw1!" }
        |> WebServer.processDeregistrationRequest acc
        |> tap (fun db -> Assert.AreEqual (uint64 i, UserDB.length db |> uint64))
      Array.fold folder db [| 49 .. -1 .. 0 |] |> ignore

    [<TestMethod;Timeout(10000)>]
    member __.``Invalid webserver deregistration test 1`` () =
      let db = __.BuildDB 50
      let ndb = { DeregisterID = "user42"; DeregisterPassword = "Pw2!" }
                |> WebServer.processDeregistrationRequest db
      isDBValid ndb
      checkDBEqual ndb db

    [<TestMethod;Timeout(10000)>]
    member __.``Invalid webserver deregistration test 2`` () =
      let db = __.BuildDB 50
      let ndb = { DeregisterID = "user4242"; DeregisterPassword = "Pw1!" }
                |> WebServer.processDeregistrationRequest db
      isDBValid ndb
      checkDBEqual ndb db


    /// Whole functionality test
    /// Total: 10pts
    [<DataTestMethod;Timeout(10000)>]
    [<DataRow(10)>]
    [<DataRow(50)>]
    [<DataRow(100)>]
    [<DataRow(200)>]
    member __.``Webserver request cycle test 1`` sz =
      let regForm = mkRegForm "userqqqq" "Pw1!" "person" "person@example.com"
      let db = WebServer.processRegistrationRequest (__.BuildDB sz) regForm
      isDBValid db
      Assert.AreEqual (uint64 sz + 1UL, UserDB.length db |> uint64)
      let ndb = { OldID = "userqqqq"; OldPassword = "Pw1!"
                  NewID = Some "cs220"; NewPassword = Some "Pw2!"
                  NewName = Some "cs220"; NewEmail = Some "cs@kaist.ac.kr" }
                |> WebServer.processUpdateRequest db
      let entry = entryOfForm regForm
      let nentry =
        mkRegForm "cs220" "Pw2!" "cs220" "cs@kaist.ac.kr" |> entryOfForm
      isDBValid ndb
      Assert.AreEqual (uint64 sz + 1UL, UserDB.length ndb |> uint64)
      Assert.IsTrue (getDBEntries ndb
                     |> List.filter (fun i  -> i = entry)
                     |> List.isEmpty)
      Assert.AreEqual (1, getDBEntries ndb
                          |> List.filter (fun i -> i = nentry)
                          |> List.length)
      Assert.AreEqual (uint64 sz,
        { DeregisterID = "cs220"; DeregisterPassword = "Pw2!" }
        |> WebServer.processDeregistrationRequest ndb
        |> UserDB.length
        |> uint64)

    [<DataTestMethod;Timeout(10000)>]
    [<DataRow(10)>]
    [<DataRow(50)>]
    [<DataRow(100)>]
    [<DataRow(200)>]
    member __.``Webserver request cycle test 2`` sz =
      let regForm = mkRegForm "userqqqq" "Pw1!" "person" "person@example.com"
      let db = WebServer.processRegistrationRequest (__.BuildDB sz) regForm
      isDBValid db
      Assert.AreEqual(uint64 sz + 1UL, UserDB.length db |> uint64)
      let ndb = { OldID = "userqqqq"; OldPassword = "Pw2!"
                  NewID = Some "cs220"; NewPassword = None
                  NewName = Some "cs220"; NewEmail = Some "cs@kaist.ac.kr" }
                |> WebServer.processUpdateRequest db
      let entry = entryOfForm regForm
      let nentry =
        mkRegForm "cs220" "Pw2!" "cs220" "cs@kaist.ac.kr" |> entryOfForm
      isDBValid ndb
      Assert.AreEqual (uint64 sz + 1UL, UserDB.length ndb |> uint64)
      Assert.IsTrue (getDBEntries ndb
                     |> List.filter (fun i  -> i = nentry)
                     |> List.isEmpty)
      Assert.AreEqual (1, getDBEntries ndb
                          |> List.filter (fun i -> i = entry)
                          |> List.length)
      let ndb = { DeregisterID = "cs220"; DeregisterPassword = "Pw3!" }
                |> WebServer.processDeregistrationRequest ndb
      Assert.AreEqual (uint64 sz + 1UL, UserDB.length ndb |> uint64)
      Assert.AreEqual (0UL, UserDB.drop ndb tPredicate
                            |> UserDB.length |> uint64)

