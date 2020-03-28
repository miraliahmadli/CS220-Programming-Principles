namespace CS220

// FIXME
// Email address should be all in lowercase. It contains three main parts: a
// local part, an at-sign (@), and a domain part. It other words, it should
// look like local@domain. The local part can have up to 64 characters, and
// the domain part can have up to 255 characters. We allow only two special
// characters "dot" (.) and "dash" (-) for both the local and the domain
// part, but we cannot use them as the first/last character of the parts. For
// example, "sangkil-cha@domain.com" is a valid email address, but
// "-sangkil-@domain.com" is not. Both local and domain parts can only have
// alphanumeric characters, dot, and dash.
type EMail = {ID:string; Domain: string}

// FIXME
module EMail =
  // FIXME
  // This function returns None if invalid input is given. See the constraints
  // described above.
  let create (str: string) = 
    let isAt x = x=64
    let isDD x = x=45 || x=46
    if str.Length>320 || str.Length=0 || isDD(int str.[0]) || isDD(int str.[str.Length-1]) then None
    else 
        let isAt x = x=64
        let isDD x = x=45 || x=46
        let isV x = (x > 64 && x < 91 ) || (x > 96 && x < 123) || x = 45 || x=46
        let rec check (str: string) c1 c2 max At= 
            if c2=max then (c1,c2)
            elif At then 
                if isAt(int str.[c2]) then (-1,-1)
                elif isV(int str.[c2]) then check str c1 (c2+1) max At
                else (-1,-1)
            else 
                if c1=max then (-1,-1)
                elif isAt(int str.[c1]) then check str c1 (c1+1) max true
                elif isV(int str.[c1]) then check str (c1+1) c2 max At
                else (-1,-1)
        let (a,b) = check str 0 0 str.Length false
        if a= -1 || a+1=str.Length || a=0  then None
        else Some {ID=str.[0..(a-1)]; Domain=str.[(a+1)..(str.Length-1)]}


  // FIXME
  let getLocalString (email: EMail) = email.ID

  // FIXME
  let getDomainString (email: EMail) = email.Domain
