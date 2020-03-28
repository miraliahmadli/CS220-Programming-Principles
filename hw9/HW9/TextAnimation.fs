module HW9.TextAnimation

open System
open System.Text

let makeAnimateFunction str : unit -> string = 
    let isUp x = (x>64)&&(x<91)
    let rev (ch: char) = 
        if (isUp (int ch)) then (string (char ((int ch)+32)))
        else (string (char ((int ch)-32)))
    let mutable cnt = -1
    let cnvrt (str: string)= 
        cnt <- cnt+1;
        cnt <- cnt%str.Length
        str.[0..(cnt-1)]+(rev str.[cnt])+str.[(cnt+1)..(str.Length-1)]
    fun() -> cnvrt str

let clearLine () =
  let top = Console.CursorTop
  Console.SetCursorPosition(0, Console.CursorTop)
  Console.Write(new string(' ', Console.WindowWidth - 1))
  Console.SetCursorPosition(0, top)

let runTextAnimation (str: string) =
  let str = str |> Encoding.ASCII.GetBytes |> Encoding.ASCII.GetString
  let animate = makeAnimateFunction str
  while true do
    clearLine ()
    animate () |> Console.Write
    Threading.Thread.Sleep (100)
  done
