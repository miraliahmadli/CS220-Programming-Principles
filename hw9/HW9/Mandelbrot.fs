module HW9.Mandelbrot
open System

let computeMandelbrot width height maxIter xMin xMax yMin yMax = 
    let dx = (float (xMax-xMin))/(float width)
    let dy = (float (yMax-yMin))/(float height)
    let va = []
    let rec iterr cur x (y: float) z =
        if cur=maxIter+1 then 0
        else 
            let (a,b) = z
            let ne = (x+(a*a)-(b*b),y+(2.0*a*b))
            let (v1,v2) = ne
            let z1= v1*v1 + v2*v2
            if z1 > 4.0 then cur
            else iterr (cur+1) x y ne
    let rec chk ans temp row col = 
        if col=width then chk (List.rev temp :: ans) [] (row-1) 0
        elif row=0 then List.rev ans
        else chk ans ((iterr 1 (xMin + (float col)*dx) (yMin + (float row)*dy) (0.0,0.0)) :: temp) row (col+1)
    chk [] [] height 0

let toString result = 
    let mutable cnt = -1
    let mutable s = ""
    //let mutable ans = ""
    let rec doRow (ent: int list) = 
        cnt <- cnt+1;
        if cnt=ent.Length then cnt<- -1;
                               //ans <- s+"\n";
                               let ans = s+"\r\n"//(string (char 13))+(string (char 10))
                               s <- "";
                               ans
        else
            if ent.[cnt]=0 then s<- s+" ";
                                doRow ent
            else s<- s+".";
                 doRow ent
    let answer = List.fold (fun x ent->x+ (doRow ent)) "" result
    answer.[0..(answer.Length-3)]

let toJsonString (result: int list list) : string = //failwith "TODO"
    let h = result.Length
    let w = if h=0 then 0 else result.[0].Length
    let mutable ans = "{\r\n  \"width\": " + (string w)+",\r\n  \"height\": " + (string h) + ",\r\n  \"values\": [\r\n    "
    let mutable s = "["
    let mutable cnt = -1
    let rec doLst (lst: int list) = 
        cnt <- cnt+1;
        if cnt = w then 
                cnt<- -1;
                let va = s+"],\r\n    "
                s<-"[";
                //printfn "%s" va
                va
        elif cnt = w-1 then 
            s <- s + (string lst.[cnt]);
            doLst lst
        else 
            s <- s + (string lst.[cnt]) + ",";
            doLst lst
    let answer = if h=0 then "" 
                 else   let k = (List.fold (fun x ent->x+ (doLst ent)) "" result)
                        k.[0..(k.Length-8)]
    ans <- ans+answer+"\r\n  ]\r\n}\r\n";
    ans
