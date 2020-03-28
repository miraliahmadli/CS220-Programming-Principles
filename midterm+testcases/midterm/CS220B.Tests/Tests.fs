namespace CS220B.Tests

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
    /// UserDB.empty Tests
    /// Total: 5pts
    [<TestMethod;Timeout(10000)>]
    member __.``Empty test 1`` () =
      Assert.AreEqual (0UL, UserDB.length UserDB.empty |> uint64)
    [<TestMethod;Timeout(10000)>]
    member __.``Empty test 2`` () =
      Assert.AreEqual (0, UserDB.select UserDB.empty tPredicate |> List.length)
    [<TestMethod;Timeout(10000)>]
    member __.``Empty test 3`` () =
      Assert.AreEqual (0, UserDB.select UserDB.empty fPredicate |> List.length)
    [<TestMethod;Timeout(10000)>]
    member __.``Empty test 4`` () =
      Assert.AreEqual (0UL, UserDB.drop UserDB.empty tPredicate
                            |> UserDB.length |> uint64)
    [<TestMethod;Timeout(10000)>]
    member __.``Empty test 5`` () =
      Assert.AreEqual (0UL, UserDB.drop UserDB.empty fPredicate
                            |> UserDB.length |> uint64)

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

    /// UserDB.insert Tests
    /// Total: 10pts
    [<DataTestMethod;Timeout(10000)>]
    [<DataRow(1)>]
    [<DataRow(5)>]
    [<DataRow(10)>]
    [<DataRow(20)>]
    [<DataRow(50)>]
    [<DataRow(100)>]
    [<DataRow(250)>]
    [<DataRow(500)>]
    [<DataRow(1000)>]
    member __.``Insert test`` i =
      __.MakeHugeDB i |> ignore

    /// UserDB.length Tests
    /// Total: 10pts
    [<DataTestMethod;Timeout(10000)>]
    [<DataRow(1)>]
    [<DataRow(5)>]
    [<DataRow(10)>]
    [<DataRow(20)>]
    [<DataRow(50)>]
    [<DataRow(100)>]
    [<DataRow(250)>]
    [<DataRow(500)>]
    [<DataRow(1000)>]
    member __.``Length test`` s =
      Assert.AreEqual (uint64 s, __.MakeHugeDB s |> UserDB.length |> uint64)

    /// UserDB.select Tests
    /// Total: 10pts
    [<DataTestMethod;Timeout(10000)>]
    [<DataRow(1, 1)>]
    [<DataRow(10, 10)>]
    [<DataRow(100, 100)>]
    [<DataRow(1000, 1000)>]
    member __.``Select test`` (sz: int, expected: int) =
      Assert.AreEqual
        (expected, UserDB.select (__.MakeHugeDB sz) tPredicate |> List.length)

    [<DataTestMethod;Timeout(10000)>]
    [<DataRow(1)>]
    [<DataRow(10)>]
    [<DataRow(100)>]
    [<DataRow(1000)>]
    member __.``Select test 2`` sz =
      Assert.AreEqual
        (0, UserDB.select (__.MakeHugeDB sz) fPredicate |> List.length)

    /// Update tests
    /// Total: 10pts
    [<DataTestMethod;Timeout(10000)>]
    [<DataRow(1)>]
    [<DataRow(10)>]
    [<DataRow(50)>]
    [<DataRow(100)>]
    member __.``Update test 1`` sz =
      let entry = __.GetEntry ()
      let db = UserDB.update (__.MakeHugeDB sz) tPredicate entry
      let updatedEntry = getDBEntries db |> getNth 0
      Assert.AreEqual (1UL, UserDB.length db |> uint64)
      Assert.AreEqual (entry, updatedEntry)

    [<DataTestMethod;Timeout(10000)>]
    [<DataRow(50, 42)>]
    [<DataRow(100, 99)>]
    [<DataRow(200, 17)>]
    member __.``Update test 2`` (sz, n) =
      let entry = __.GetEntry ()
      let dbBase = __.MakeHugeDB sz
      let predicate i = getDBEntries dbBase |> getNth n = i
      let newDB = UserDB.update dbBase predicate entry
      (entry :: (getDBEntries dbBase |> List.filter (predicate >> not)))
      |> checkEntriesEqual (getDBEntries newDB)

    [<TestMethod;Timeout(10000)>]
    member __.``Update test 3``() =
      let db = __.MakeHugeDB 100
      let entry = getDBEntries db |> getNth 0
      let entry1 = getDBEntries db |> getNth 1
      let predicate i = i = entry
      let updatedDB = UserDB.update db predicate entry1
      Assert.AreEqual (99UL, UserDB.length updatedDB |> uint64)

    /// Drop tests
    /// Total: 10pts
    [<TestMethod;Timeout(10000)>]
    member __.``Drop test 1``() =
      Assert.AreEqual (0UL, UserDB.drop (__.MakeHugeDB 10) tPredicate
                            |> UserDB.length |> uint64)
    [<TestMethod;Timeout(10000)>]
    member __.``Drop test 2``() =
      Assert.AreEqual (10UL, UserDB.drop (__.MakeHugeDB 10) fPredicate
                             |> UserDB.length |> uint64)
    [<DataTestMethod;Timeout(10000)>]
    [<DataRow(1)>]
    [<DataRow(10)>]
    [<DataRow(20)>]
    [<DataRow(50)>]
    member __.``Drop test 3`` sz =
      let db = __.MakeHugeDB sz
      let predicate i = getDBEntries db |> getNth 0 = i
      Assert.AreEqual
        (uint64 (sz - 1), UserDB.drop db predicate |> UserDB.length |> uint64)

    [<DataTestMethod;Timeout(10000)>]
    [<DataRow(50)>]
    [<DataRow(100)>]
    member __.``Drop test 4``sz =
      let db = __.MakeHugeDB sz
      let folder acc elem =
        let predicate i = getDBEntries acc |> getNth 0 = i
        let nDB = UserDB.drop acc predicate
        getDBEntries acc
        |> List.filter (predicate >> not)
        |> checkEntriesEqual (getDBEntries nDB)
        nDB
      Array.init sz (fun i -> i) |> Array.fold folder db |> ignore
