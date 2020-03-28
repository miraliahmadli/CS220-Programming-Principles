module HW7.MySolution

let countLetter s1 s2 =
  if s1="" || s2="" then 0UL
  else
    let len1 = String.length s1
    let len2 = String.length s2
    if len1 < len2 then 0UL
    else
        let rec find cur1 cnt =
            if cur1=len1-len2+1 then cnt
            elif s1.[cur1..cur1+len2-1] = s2 then find (cur1+1) (cnt+1UL)
            else find (cur1+1) cnt
        find 0 0UL


let diagonal (matrix : 'a SqMatrix) =
  let len = List.length matrix
  let rec count ans cur = 
    if cur=len then ans
    else count (matrix.[cur].[cur] :: ans) (cur+1)
  List.rev (count [] 0)

let transpose (matrix : 'a SqMatrix) =
  if matrix=[] then []
  else
      let len = List.length matrix
      let rec transpose (ans : 'a SqMatrix) temp row col = 
        if row=len then transpose (List.rev temp::ans) [] 0 (col+1)
        elif col=len then ans
        else transpose ans (matrix.[row].[col] :: temp) (row+1) col
      List.rev (transpose [] [] 0 0)

let rec rotate (l: 'a list) n =
  if n=0 then l
  elif n>0 then 
    let len = (List.length l) - n%(List.length l)
    let temp = l
    let rec rotR (temp2: 'a list) cur1 cur2 (temp: 'a list)=
        if cur1<len then rotR temp2 (cur1+1) cur2 temp.Tail
        elif cur2<(n% (List.length l)) then rotR temp2.Tail cur1 (cur2+1) temp
        else  temp@(List.rev temp2)
    rotR (List.rev l) 0 0 l
  else 
    rotate l ((List.length l) + n%(List.length l))

let rec hanoi a b n =
  if a=b || n=0 then []
  elif n=1 then [(a,b)]
  else
    let c = 6 - a - b
    (hanoi a c (n-1))@[(a,b)]@(hanoi c b (n-1))
        

