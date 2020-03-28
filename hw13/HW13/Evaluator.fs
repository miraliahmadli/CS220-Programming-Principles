module HW13.Evaluator
open System.Collections

exception UnknownVariableException
exception IntOverflowException


let rec evaluate y (var: Map<string,_>) = match y with
                                            | Num x -> x
                                            | Var x -> match var.TryFind(x) with
                                                       | Some v -> v
                                                       | None -> raise UnknownVariableException
                                            | Mul (x,z) -> match (int64 (evaluate x var))*(int64(evaluate z var)) with
                                                            | x -> if x>int64(2147483647) || x< int64(-2147483648) then raise IntOverflowException
                                                                   else x |> int
                                            | Add (x,z) -> match (int64 (evaluate x var))+(int64(evaluate z var)) with
                                                            | x -> if x>int64(2147483647) || x< int64(-2147483648) then raise IntOverflowException
                                                                   else x |> int
                                            | Sub (x,z) -> match (int64 (evaluate x var))-(int64(evaluate z var)) with
                                                            | x -> if x>int64(2147483647) || x< int64(-2147483648) then raise IntOverflowException
                                                                   else x |> int
                                            | Div (x,z) -> match (int64 (evaluate x var))/(int64(evaluate z var)) with
                                                            | x -> if x>int64(2147483647) || x< int64(-2147483648) then raise IntOverflowException
                                                                   else x |> int
                                            | _ -> 0
let rec travel (lst: Expr list) (var: Map<string,_>) =  if lst=[] then None
                                                        else match lst.Head with
                                                                    | Let (x,y) -> if lst.Tail=[] then None  
                                                                                    else travel lst.Tail (var.Add(x,(evaluate y var)))
                                                                    | _ -> if lst.Tail=[] then evaluate lst.Head var |> Some
                                                                            else travel lst.Tail var
                            

let eval (stmts: Expr list): int option = 
        travel stmts Map.empty