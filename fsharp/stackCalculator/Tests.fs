module StackCalculatorTests

open Xunit
open FsUnit.Xunit

[<Fact>]
let ``Pushing to stack changes its size`` () =
    let stack = [1.0;2.0;3.0]
    let result = StackCalculator.push 4.0 stack
    result |> should haveLength 4

[<Fact>]
let ``Element pushed to stack on top`` () =
    let stack = [1.0;2.0;3.0]
    let result = StackCalculator.push 4.0 stack
    result |> List.head |> should equal 4.0

[<Fact>]
let ``Popping reduces stack size`` () =
    let stack = [1.0;2.0;3.0]
    let (_, result) = StackCalculator.pop stack
    result |> should haveLength 2

[<Fact>]
let ``Popping returns element from top of the stack`` () =
    let stack = [1.0;2.0;3.0]
    let (result, _) = StackCalculator.pop stack
    result |> should equal 1.0

[<Fact>]
let ``Popping empty stack should cause exception`` () =
    let stack = []
    (fun () -> StackCalculator.pop stack |> ignore) |> should throw typeof<System.Exception>

[<Fact>]
let ``Popping stack with one element should leave it empty`` () =
    let stack = [1.0]
    let (_, result) = StackCalculator.pop stack
    result |> should be Empty

[<Fact>]
let ``Adding reduces stack size by one`` () =
    let stack = [1.0;2.0;3.0]
    let result = StackCalculator.add stack
    result |> should haveLength 2

[<Fact>]
let ``Adding adds correct result to stack top`` () =
    let stack = [10.0;2.0;3.0]
    let result = StackCalculator.add stack
    result |> List.head |> should equal 12.0

[<Fact>]
let ``Adding on stack with 2 element should work`` () =
    let stack = [10.0;2.0]
    let result = StackCalculator.add stack
    result |> List.head |> should equal 12.0
    result |> should haveLength 1

[<Fact>]
let ``Adding on empty stack should cause exception`` () =
    let stack = []
    (fun () -> StackCalculator.add stack |> ignore) |> should throw typeof<System.Exception>

[<Fact>]
let ``Adding on stack with one element should cause exception`` () =
    let stack = [1.0]
    (fun () -> StackCalculator.add stack |> ignore) |> should throw typeof<System.Exception>

[<Fact>]
let ``Subtracting works in standard case`` () =
    let stack = [1.0;2.0;3.0]
    let result = StackCalculator.subtract stack
    result |> should equal [-1.0;3.0]

[<Fact>]
let ``Chaining operations works`` () =
    let stack = [1.0;2.0;3.0;4.0;5.0]
    let result =
        stack |> StackCalculator.add
        |> StackCalculator.add
        |> StackCalculator.subtract
        |> StackCalculator.push 10.0
        |> StackCalculator.add

    result |> should equal [12.0;5.0]