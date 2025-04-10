open System

printfn "Добро пожаловать, пользователь! Эта программа реализует стандартные операции над списками."

// функция для интерфейса 
let rec start () = 
    printfn "1. Показать операции"
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

// функция для ввода чисел от пользователя
let rec numInput () = 
    try 
        float (Console.ReadLine())
    with 
        | :? System.FormatException ->
            printfn "Неверный ввод. Пожалуйста, введите число: "
            numInput () // Рекурсивный вызов для повторного запроса
        | ex ->
            printfn "Произошло переполнение! Введите число: "
            numInput ()    

// функция для создание списка
let randList N =
    [ 
        for i in 1 .. N do
            yield (float(i*10) + float(N*2) + float(N-i))
    ]

// функция для добавления в начало списка
let addList listik num = 
    num :: listik

// функция для удаления из списка
let rec delList listik num = 
    match listik with 
    | [] -> []
    | head :: tail when head = num -> tail
    | head :: tail -> head :: delList tail num 

// функция для поиска по значению
let rec findList listik num = 
    match listik with 
    | [] -> false 
    | head :: tail when head = num -> true
    | head :: tail -> findList tail num 

// функция для сцепки списков
let uniteList listik1 listik2 = 
    listik1 @ listik2

// функция для поиска по номеру
let rec lookList listik id = 
    if (id-1) >= List.length(listik) then 
        printfn "Номер больше количества чисел в списке! Введите номер: "
        let new_id = int(numInput ())
        lookList listik new_id
    elif (id-1) < 0 then 
        printfn "Номер не может быть меньше 1! Введите номер: "
        let new_id = int(numInput ())
        lookList listik new_id
    else 
        listik[id-1]

let rec cycleWork () = 
    let help = start () 

    if help = 1 then 
        printfn "Создание 'случайного' списка"
        printfn "Введите размерность списка: "
        let N = int(numInput ())
        let sp1 = randList N

        // Добавление
        printfn "Добавление элемента"
        printfn "Cписок: %A" sp1
        printfn "Введите добавляемое число: "
        let adder = numInput ()

        let sp2 = addList sp1 adder 
        printfn "Cписок после добавления элемента в начало: %A" sp2
        printfn ""

        // Удаление
        printfn "Удаление элемента"
        printfn "Cписок: %A" sp2
        printfn "Введите удаляемое число: "
        let deleter = numInput ()

        let sp3 = delList sp2 deleter
        printfn "Cписок после удаления элемента: %A" sp3
        printfn ""

        // Поиск элемента
        printfn "Поиск элемента"
        printfn "Cписок: %A" sp3
        printfn "Введите поисковое число: "
        let finder = numInput ()

        let isItThere = findList sp3 finder
        printfn "Нахождение числа %f: %b" finder isItThere
        printfn ""

        // Сцепка двух списков
        printfn "Сцепка двух списков"
        printfn "Cписок 1: %A" sp3
        printfn "Введите размерность для списка 2:"
        let N2 = int(numInput ())
        let sp_add = randList N2

        printfn "Cписок 2: %A" sp_add

        let sp4 = uniteList sp3 sp_add
        printfn "Объединенные списки: %A" sp4
        printfn ""

        // Поиск по элемента идентификатору 
        printfn "Поиск элемента по номеру"
        printfn "Cписок: %A" sp4
        printfn "Введите номер:"
        let id = int(numInput ())

        let elem = lookList sp4 id
        printfn "Элемент по номеру %d: %f" id elem
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