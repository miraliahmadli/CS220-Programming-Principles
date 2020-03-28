module HW9.MySolution

open System

let usage () =
  printfn "KAIST - CS220"
  printfn "- To run text animation:"
  printfn "    dotnet run -- text <input string>"
  printfn "- To run mandelbrot:"
  printfn "    dotnet run -- mandelbrot <width> <height> <maxiter> <xmin> <xmax> <ymin> <ymax>"

[<EntryPoint>]
let main args =
  if Array.length args = 0 then usage ()
  else
    match args.[0] with
    | "text" -> TextAnimation.runTextAnimation args.[1]
    | "mandelbrot" when Array.length args = 8 ->
      let width = Convert.ToInt32 args.[1]
      let height = Convert.ToInt32 args.[2]
      let maxiter = Convert.ToInt32 args.[3]
      let xmin = Convert.ToDouble args.[4]
      let xmax = Convert.ToDouble args.[5]
      let ymin = Convert.ToDouble args.[6]
      let ymax = Convert.ToDouble args.[7]
      Mandelbrot.computeMandelbrot width height maxiter xmin xmax ymin ymax
      |> Mandelbrot.toJsonString
      |> Console.WriteLine
    | _ -> usage ()
  0
