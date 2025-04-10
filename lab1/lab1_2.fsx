open System

printfn "Добро пожаловать, пользователь! Эта программа вносит поциферно число в список"

let rec start () = 
    printfn "1. Начать ввод числа"
    printfn "2. Выйти из программы"
    printfn "Выберите действие: "

    let h = Console.ReadLine()

    try
        int h
    with
    | ex ->
        printfn "Пожалуйста, выберите действие."
        printfn ""

        start ()

let rec str () =
    printf "Введите число: "

    Console.ReadLine()

let isNum stroka =
    try 
        let useless = float(stroka)
        true
    with 
        | ex -> false

let rec listMaker stroka = 
    if stroka = "" then 
        []
    else
        match stroka[0] with 
        | '0' | '1' | '2' | '3' | '4' | '5' | '6' | '7' | '8' | '9' -> (int(stroka[0]) - 48) :: listMaker(stroka[1..])
        | _ -> listMaker(stroka[1..])

let show a = 
    printfn "Результирующий список: %A" a 

let rec cycleWork () = 
    let help = start () 

    if help = 1 then 
        let temp = str()
        if isNum(temp) then 
            let spisok = listMaker (temp)
            printfn ""

            show spisok
            printfn ""

            cycleWork ()
        else
            printfn "Введенная строка не число!"
            printfn ""

            cycleWork ()
    elif help = 2 then
        printfn "Завершение работы..."
        printfn ""

        exit 0
    else
        printfn "Пожалуйста, выберите действие."
        printfn ""

        cycleWork ()

let main = 
    cycleWork ()