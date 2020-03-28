module CS220.Main

open CS220

////////////////////////////////////////////////////////////////////////////////
// You can freely change the main function for your testing. We will create a
// separate test for grading.
////////////////////////////////////////////////////////////////////////////////

[<EntryPoint>]
let main _argv =
  // Create an empty DB for testing.
  let db = UserDB.empty
  // A dummy registration form.
  let regForm =
    { RegistrationID = "Mirali"
      RegistrationPassword = "Mirali!2"
      RegistrationName = "Mirali"
      RegistrationEmail = "miraliahmadli@gmail.com" }
  let db = WebServer.processRegistrationRequest db regForm

  let regForm =
    { RegistrationID = "OOOOOye"
      RegistrationPassword = "Mirali!1232"
      RegistrationName = "Mirali"
      RegistrationEmail = "miraliahmadli@gmail.com" }
  let db = WebServer.processRegistrationRequest db regForm
  UserDB.toString db |> printfn "%s" // This is only for your debugging.
  // A dummy user update form.
  let updateForm =
    { OldID = "Mirali"
      OldPassword = "Mirali!2"
      NewID = Some "Borzu"
      NewPassword = Some "Kele!2"
      NewName = None
      NewEmail = None }
  let db = WebServer.processUpdateRequest db updateForm
  UserDB.toString db |> printfn "%s" // This is only for your debugging.
  // A dummy user deregistration form.
  let deregForm = { DeregisterID = "Borzu"; DeregisterPassword = "Kele!2" }
  let db = WebServer.processDeregistrationRequest db deregForm
  UserDB.toString db |> printfn "%s" // This is only for your debugging.
  // Test the select function
  UserDB.select db (fun _entry -> false)
  |> List.iter (UserDBEntry.toString >> printfn "%s")
  0 // return an integer exit code
