module StackCalculator
    let push x (stack) =
        x::stack

    let pop stack =
        match stack with
        | top::rest -> (top, rest)
        | [] -> failwith "stack underflow"

    let private performOperation stack operation: float list =
        match stack with
        | first::second::rest -> ((operation first second)::rest)
        | _::_ -> failwith "tried to perform operation on one element"
        | [] -> failwith "stackunderflow"

    let add stack =
        performOperation stack (+)

    let subtract stack =
        performOperation stack (-)