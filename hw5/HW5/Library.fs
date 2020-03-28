module HW5.MySolution

open System

// Prob 1
let area shape = match shape with
    | Circle a-> Math.PI*a*a
    | Square a-> a*a
    | Triangle (a, b, c) -> 
        let p = (a+b+c)/2.0
        sqrt (p*(p-a)*(p-b)*(p-c))

let pair (x: int) (y: int) m : int = m x y
    
// Prob 2
let fst p = p (fun first second -> first)  
    

// Prob 3
let isEarly t1 t2 = 
    let th1 = t1.AMPM
    let th2 = t2.AMPM
    if th1 = AM && th2 = PM then true
    elif th2 = AM && th1 = PM then false
    else 
        let f1 = t1.Hours
        let f2 = t2.Hours
        if f1 > f2 then false
        elif f1 < f2 then true
        else
            if t1.Minutes < t2.Minutes then true
            else false

// Prob 4
let rec addMinutes t m = 
    if m=0 then t
    elif m>0 then 
        if t.Minutes=59 then 
            if t.Hours = 11 then 
                if t.AMPM=AM then addMinutes {t with Hours = 0; Minutes = 0; AMPM= PM} (m-1)
                else addMinutes {t with Hours = 0; Minutes = 0; AMPM= AM} (m-1)
            else addMinutes {t with Hours = t.Hours+1; Minutes = 0} (m-1)
        else addMinutes {t with Minutes = t.Minutes+1} (m-1)
    else
        if t.Minutes=0 then
            if t.Hours=0 then 
                if t.AMPM=AM then addMinutes {t with Hours = 11; Minutes = 59; AMPM= PM} (m+1)
                else addMinutes {t with Hours = 11; Minutes = 59; AMPM= AM} (m+1)
            else addMinutes {t with Hours = t.Hours-1; Minutes = 59} (m+1)
        else addMinutes {t with Minutes = t.Minutes-1} (m+1)

// Prob 5
let mirrorX line = match line with | StraightLine(a,b) -> StraightLine(-a,-b)

let mirrorY line = match line with | StraightLine(a,b) -> StraightLine(-a,b)
