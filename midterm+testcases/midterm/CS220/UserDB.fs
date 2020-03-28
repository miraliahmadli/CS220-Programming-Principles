namespace CS220

// FIXME
// Each DB entry contains information about user ID (UserID), password
// (Password), name (UserName), and email (EMail). Each element should follow a
// specific format as described in each type.
type UserDBEntry = {ID:UserID; User:UserName; Password:Password; Email:EMail}

module UserDBEntry =
  // (optional) You can implement this function for your debugging.
  let toString (entry: UserDBEntry) = "User:"+entry.ID.User+"\n"+"Username"+entry.User.Name+"\n"+"Pass"+entry.Password.Key+"\n"+"email"+entry.Email.ID+entry.Email.Domain

type Predicate = UserDBEntry -> bool

// FIXME
// UserDB is a collection of UserDBEntry.
type UserDB = {Entries: UserDBEntry list}

module UserDB =

  //////////////////////////////////////////////////////////////////////////////
  // FIXME: This module currently contains dummy code.
  //////////////////////////////////////////////////////////////////////////////

  // FIXME
  // Returns empty UserDB.
  let empty = {Entries=[]}

  /// FIXME
  /// Returns the length of the given DB.
  let length (db: UserDB) = db.Entries.Length

  // FIXME
  /// Register a user to the given DB. This function takes in a UserDB and a
  /// UserDBEntry as input, and returns an updated DB. Note that User IDs in
  /// the DB should be unique: there cannot be two entries in the DB with a
  /// same user id.
  let insert (db: UserDB) entry = 
        if length db = 0 then {Entries= [entry]}
        else
            let len = length db
            let rec check (lst: UserDBEntry list) cur max=
                if cur=max then true
                elif lst.[cur].ID = entry.ID then false
                else check lst (cur+1) max
            if check db.Entries 0 len then {Entries= (entry::db.Entries)}
            else db

  // FIXME
  /// Select a list of entries in the DB, which satisfy the given predicate. The
  /// predicate is a function that takes in a UserDBEntry and returns bool.
  let select (db: UserDB) (predicate: Predicate) = 
        let rec fill (lst: UserDBEntry list) ans cur max =
            if cur= max then ans
            elif predicate lst.[cur] then fill lst (lst.[cur]::ans) (cur+1) max
            else fill lst ans (cur+1) max
        fill db.Entries [] 0 (length db)

  // FIXME
  /// Select a list of entries in the DB, which satisfy the given predicate, and
  /// replace them with the given entry.
  let update (db: UserDB) (predicate: Predicate) (entry: UserDBEntry) = 
        let rec fill (lst: UserDBEntry list) ans cur max ch =
            if cur=max then ans
            elif ch then 
                if predicate lst.[cur] then fill lst ans (cur+1) max ch
                else fill lst (lst.[cur]::ans) (cur+1) max ch
            else
                if predicate lst.[cur] then fill lst (entry::ans) (cur+1) max true
                else fill lst (lst.[cur]::ans) (cur+1) max ch
        let ans = fill db.Entries [] 0 (length db) false
        {db with Entries=ans}

  // FIXME
  /// Drop a list of entries in the DB, which satisfy the given predicate.
  let drop (db: UserDB) (predicate: Predicate) = 
    let rec fill (lst: UserDBEntry list) ans cur max =
            if cur= max then ans
            elif predicate lst.[cur] then fill lst ans (cur+1) max
            else fill lst (lst.[cur]::ans) (cur+1) max
    let ans = fill db.Entries [] 0 (length db)
    {db with Entries=ans}

  // (optional) This returns the entire contents of the given DB in a string.
  // You can implement this function for your debugging. We will not evaluate
  // this function for this midterm.
  let toString (db: UserDB) = 
    //let sum (x: UserDBEntry) = x.ID.User+x.User.Name+x.Password.Key+x.Email.ID+x.Email.Domain
    List.fold (fun sum (x: UserDBEntry) -> sum+(UserDBEntry.toString x)) "" db.Entries
