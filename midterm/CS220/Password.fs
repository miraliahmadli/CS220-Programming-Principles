namespace CS220

// FIXME
// Password should contain at least one lowercase letter, one uppercase letter,
// one numeric digit, and one special character. The maximum length is 40. For
// simplicity, we consider the following six characters as a special character.
// Other characters are not allowed for passwords. In other words, only English
// alphabet characters, digits, and the following six characters are allowed
// for a password.
//
// A list of special characters.
// (1) ' ': a space character
// (2) '!': exclamation mark
// (3) '#': hash mark
// (4) '%': percent mark
// (5) '.': dot
// (6) ',': comma
type Password = {Key: string}

// FIXME
module Password =
  // FIXME
  // This function returns None if invalid input is given. See the constraints
  // described above.
  let create (str: string) = 
    //let isInRange x = (x > 64 && x < 91 ) || (x > 96 && x < 123) || x = 32 || x=33 || x=35 || x=46 || x=44 ||x=37 || (x>47 && x<58)
    let isUp x = (x > 64 && x < 91 )
    let isLow x =(x > 96 && x < 123)
    let isChar x =  (x=32 || x=33 || x=35 || x=46 || x=44 ||x=37)
    let isNum x = (x>47 && x<58)
    if str.Length>40 then None
    else 
        let rec check (str: string) cur max Up Ch Lo Nu =
            if cur=max then Up && Ch && Lo && Nu
            else 
                if isUp(int str.[cur]) then check str (cur+1) max true Ch Lo Nu
                elif isLow(int str.[cur]) then check str (cur+1) max Up Ch true Nu
                elif isChar(int str.[cur]) then check str (cur+1) max Up true Lo Nu
                elif isNum(int str.[cur]) then check str (cur+1) max Up Ch Lo true
                else false
        if (check str 0 str.Length false false false false) then Some {Key=str}
        else None

  // FIXME
  let toString (p: Password) = p.Key
