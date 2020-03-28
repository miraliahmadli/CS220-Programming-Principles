namespace CS220.Tests

open CS220
open Microsoft.VisualStudio.TestTools.UnitTesting

[<TestClass>]
type TestClass () =
  [<TestMethod;Timeout(10000)>]
  member __.``Test`` () =
    let tPredicate _ = true
    let regForm = { RegistrationID = "user"
                    RegistrationPassword = "Pw1!"
                    RegistrationName = "person"
                    RegistrationEmail = "person@example.com" }
    let db = WebServer.processRegistrationRequest UserDB.empty regForm
    Assert.AreEqual (1UL, UserDB.length db |> uint64)
    let ndb = { OldID = "user"; OldPassword = "Pw1!"
                NewID = Some "cs220"; NewPassword = None
                NewName = Some "cs220"; NewEmail = Some "cs@kaist.ac.kr" }
              |> WebServer.processUpdateRequest db
    Assert.AreEqual (1UL, UserDB.length ndb |> uint64)
    let ndb = { DeregisterID = "cs220"; DeregisterPassword = "Pw2!" }
              |> WebServer.processDeregistrationRequest ndb
    Assert.AreEqual (1UL, UserDB.length ndb |> uint64)
    Assert.AreEqual (List.empty<UserDBEntry>, UserDB.select (UserDB.drop ndb tPredicate) tPredicate)