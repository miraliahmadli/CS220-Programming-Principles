module HW11.Main

[<EntryPoint>]
let main _ =
  let molestream = MoleEventStream.create 3u 1
  let malletstream = MalletEventStream.create 0
  Score.compute molestream malletstream 20u |> printfn "%d"
  0
