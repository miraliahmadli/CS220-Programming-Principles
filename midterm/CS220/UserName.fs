namespace CS220

// FIXME
// UserName is just a string, and its size can be up to 30 characters.
type UserName = {Name: string}

// FIXME
module UserName =
  // FIXME
  // This function returns None if invalid input is given. See the constraints
  // described above.
  let create (str: string) = 
    if str.Length>29 then None
    elif str="" then None
    else Some {Name=str}

  // FIXME
  let toString (n: UserName) = n.Name
