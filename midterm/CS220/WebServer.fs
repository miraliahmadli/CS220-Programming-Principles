module CS220.WebServer

open System.Xml.Linq

/// FIXME
/// Translate RegistrationForm to UserDBEntry option. If translation is not
/// successful, i.e., when an invaild input is given, this function returns
/// None.
let translateRegisterForm (form: RegistrationForm) =
    let crEm = match EMail.create form.RegistrationEmail with 
                   | None -> {ID=""; Domain=""}
                   | Some x -> x
    let crUs = match UserID.create form.RegistrationID with 
                    | None -> {User=""}
                    | Some x -> x
    let crPa = match Password.create form.RegistrationPassword with 
                   | None -> {Key=""}
                   | Some x->x
    let crNa = match UserName.create form.RegistrationName with 
                    |None -> {Name=""}
                    |Some x->x
    if  crEm.ID="" || crUs.User="" || crPa.Key="" || crNa.Name="" then None
    else Some {ID=crUs; User=crNa; Password=crPa; Email=crEm}

/// (No need to fix this function)
/// Process a registration request.
let processRegistrationRequest db (form: RegistrationForm) =
  match translateRegisterForm form with
  | Some entry -> UserDB.insert db entry
  | None -> db

/// FIXME
/// Process a user update request. The server allows only the authenticated user
/// to modify the information of itself. There are four optional fields, and the
/// authenticated user can change any of the data. If an optional field is given
/// as None, it means the user will not modify the corresponding field.
let processUpdateRequest db (form: UpdateUserForm) = 
    let pred (x: UserDBEntry) =  x.ID.User=form.OldID && form.OldPassword=x.Password.Key
    let lst = UserDB.select db pred
    if lst=[] then db
    else
        let elem=lst.Head
        let id = match form.NewID with 
                    |None -> elem.ID
                    |Some x-> match UserID.create x with 
                                    | None -> {User=""}
                                    | Some x -> x 
        let us =match form.NewName with 
                    |None -> elem.User
                    |Some x-> match UserName.create x with 
                                    | None -> {Name=""}
                                    | Some x -> x 
        let em = match form.NewEmail with 
                    |None -> elem.Email
                    |Some x-> match EMail.create x with 
                                    | None -> {ID="";Domain=""}
                                    | Some x -> x 
        let pa = match form.NewPassword with 
                    |None -> elem.Password
                    |Some x->   match Password.create x with 
                                    | None -> {Key=""}
                                    | Some x -> x 
        if id.User=""|| us.Name="" || em.ID="" || pa.Key="" then db
        else
            let va= {ID=id; User=us; Password=pa; Email=em}
            UserDB.update db pred va
/// FIXME
/// Process a user removal request. This process should work only when the
/// provided ID and the password match with one of the entry in the DB. If they
/// match, this function returns an updated DB.
let processDeregistrationRequest db (form: DeregisterForm) = 
    let pred (x: UserDBEntry) =  x.ID.User=form.DeregisterID && x.Password.Key=form.DeregisterPassword
    UserDB.drop db pred
