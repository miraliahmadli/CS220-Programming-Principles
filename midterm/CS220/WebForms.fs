namespace CS220

/// This type represents raw data provided by a user for user registration. You
/// can consider this as data sent from your browser to a web server when you
/// click a submit button in a web form.
type RegistrationForm = {
  RegistrationID: string
  RegistrationPassword: string
  RegistrationName: string
  RegistrationEmail: string
}

/// This type represents raw data provided by a user for user information
/// update. You can consider this as data sent from your browser to a web server
/// when you click a submit button in a web form. The OldID and OldPassword
/// field are required to check the identity of the user. This form will be
/// successfully processed by the web server only if the user provides the
/// correct user ID and password (i.e. authenticated). And the server allows
/// only the user to modify the information of itself. There are four optional
/// fields, and the authenticated user can change any of the data. If an
/// optional field is given as None, it means the user will not modify the
/// corresponding field.
type UpdateUserForm = {
  OldID: string
  OldPassword: string
  NewID: string option
  NewPassword: string option
  NewName: string option
  NewEmail: string option
}


/// This type represents raw data provided by a user for leaving the web server.
/// You can consider this as data sent from your browser to a web server when
/// you click a submit button in a web form when a user want to withdraw their
/// membership from the web site. The deregistration process should only be
/// successful when the provided ID and the password match with one of the entry
/// in the DB.
type DeregisterForm = {
  DeregisterID: string
  DeregisterPassword: string
}