namespace CS220

// FIXME
// User ID should be unique in the database. The maximum length is 20. If a user
// tries to register a user with an existing user ID, the request should fail.
type UserID = {User: string}

// FIXME
module UserID =
  // FIXME
  // This function returns None if invalid input is given. See the constraints
  // described above.
  let create (str: string) = 
    if str.Length>20 then None
    elif str="" then None
    else Some {User=str}

  // FIXME
  let toString (p: UserID) = p.User
