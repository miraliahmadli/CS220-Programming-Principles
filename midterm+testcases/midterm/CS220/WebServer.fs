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
    if form.NewEmail=None || form.NewID=None || form.NewName=None || form.NewPassword=None then db
    else 
        let pred (x: UserDBEntry) =  x.ID.User=form.OldID && form.OldPassword=x.Password.Key
        let id = match form.NewID with 
                    | None -> ""
                    | Some x->x
        let us = match form.NewName with
                    | None -> ""
                    | Some x->x
        let em = match form.NewEmail with
                    | None -> ""
                    | Some x->x
        let pa = match form.NewPassword with 
                    | None -> ""
                    | Some x->x
        //let Em = match EMail.create em with 
            //       | None -> {ID=""; Domain=""}
          //         | Some x -> x
        let va =  {RegistrationID=id;RegistrationEmail=em;RegistrationName=us;RegistrationPassword=pa}
        match  translateRegisterForm va with 
                    | None -> db
                    | Some x -> UserDB.update db pred x
        

/// FIXME
/// Process a user removal request. This process should work only when the
/// provided ID and the password match with one of the entry in the DB. If they
/// match, this function returns an updated DB.
let processDeregistrationRequest db (form: DeregisterForm) = 
    let pred (x: UserDBEntry) =  x.ID.User=form.DeregisterID && x.Password.Key=form.DeregisterPassword
    UserDB.drop db pred
