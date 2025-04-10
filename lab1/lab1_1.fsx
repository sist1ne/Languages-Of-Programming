open System

printfn "Добро пожаловать, пользователь! Эта программа определяет четность введенных чисел."

let rec start () = 
    printfn "1. Начать ввод чисел"
    printfn "2. Выйти из программы"
    printfn "Выберите действие: "

    let h = Console.ReadLine()

    try
        int h
    with
    | ex ->
        printfn "Пожалуйста, выберите действие."
        start ()

let rec getInput () =
    printf "Введите число, для прекращения ввода введите 'stop' или 0: "
    let str = Console.ReadLine()

    if str <> "stop" then
        try
            int str
        with
        | :? System.FormatException ->
            printfn "Неверный ввод. Пожалуйста, введите число."
            getInput () 

        | ex ->
            printfn "Произошло переполнение!"
            getInput ()
    else 
        0

let rec listMaker num = 
    if num = 0 then 
        []
    else
       if num % 2 = 0 then
            true :: listMaker (getInput())
       else 
            false :: listMaker (getInput())

let show a = 
    printfn "Результирующий список: %A" a 

let rec cycleWork () = 
    let help = start () 

    if help = 1 then 
        let spisok = listMaker (getInput())
        printfn ""

        show spisok
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
    0