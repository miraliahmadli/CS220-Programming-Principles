module HW6.MySolution

let car lst = 
    match lst with 
        | [] -> failwith "Empty list"
        | hd :: _ -> hd

let cdr lst = 
    match lst with  
        | [] -> []
        | _::tl -> tl

let rec length lst va =
    match lst with
        | [] -> va
        | _ -> length (cdr lst) (va+1)
   
let rec rev lst ne = 
        if lst=[] then ne
        else rev (cdr lst) ((car lst) :: ne)

let removeOdd lst =
  let rec find ans ls = 
        if ls=[] then ans
        elif (car ls)%2=0 then find ((car ls)::ans) (cdr ls)
        else find ans (cdr ls)
  rev (find [] lst) []

let getSmallest lst =
  if lst=[] then None
  else
    let ans = car lst
    let rec find_smallest lst ans =
        if lst=[] then ans
        else 
            if ans> (car lst) then find_smallest (cdr lst) (car lst)
            else find_smallest (cdr lst) ans
    Some (find_smallest lst ans)

let take lst len =
    if len=0u ||lst=[] then []
    else
      let rec get ans lst len =
            if len=0u || lst=[] then ans
            else get ((car lst) :: ans) (cdr lst) (len-1u)
      rev (get [] lst len) []

let runLength lst =
  if lst=[] then []
  else
    let rec find ans cur lst count = 
        if lst=[] then ((cur,count)::ans)
        elif (car lst) = cur then find ans cur (cdr lst) (count+1)
        else find ((cur,count)::ans) (car lst) (cdr lst) 1
    rev (find [] (car lst) lst 0) []

let isPalindrome lst =
  lst = (rev lst [])

let rec slice lst a b =
  if a<1 && b<1 then []
  elif a>b then slice lst b a
  elif a>(length lst 0) then []
  else
    let rec get ans lst len1 len =
            if lst=[] then ans
            elif len1>1 then get ans (cdr lst) (len1-1) len
            elif len=0 then ans
            else get ((car lst) :: ans) (cdr lst) 0 (len-1)
    rev (get [] lst a (b-a+1)) []
