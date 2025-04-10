open System

printfn "Добро пожаловать! \nЭта программа добавляет в начало каждого элемента последовательности заданный символ."

let rec AddInput () =  
    printfn "\nВведите символ, который хотите добавить в начало каждого элемента: "
    let succ, res = Char.TryParse(Console.ReadLine())

    if succ = true then 
        res
    else 
        printfn "Введите один символ!"
        AddInput ()

let rec GetN () = 
    printf "Введите количество элементов для последовательности: "
    let succ, res = Int32.TryParse(Console.ReadLine())

    if succ = true then 
        if (res >= 0) then 
            res
        else 
            printfn "Количество элементов не может быть отрицательным! \n"
            GetN ()
    else 
        printfn "Пожалуйста, введите число! \n"
        GetN ()

let PrintOut (sequence) =
    Seq.iter (fun elem -> printf "'%s'; " elem) sequence
    printfn ""

let HandFill (size) =
    [
        for i in 1..size do 
            printf "Введите %d элемент последовательности: " i
            yield Console.ReadLine()
    ]

let alphabet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTYVWXYZабвгдеёжзийклмнопрстуфхцчшщъыьэюяАБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ0123456789" 
let alp_size = 128

let GenerateWord (size) =
    [
        for i in 1..size do
            let temp = Random().Next(0, alp_size-1) 
            yield alphabet[temp]
    ]

let GenerateSentence (size) =
    [                            
        for i in 1..size do                        
            let word_size = Random().Next(1, 6)
            yield String.Concat(GenerateWord (word_size))
    ]

let RandFill (size) =
    [
        for i in 1..size do
            let sent_size = Random().Next(1, 6)
            let sentence = GenerateSentence (sent_size)
            yield String.Join(" ", sentence)
    ]

let rec InputPath () = 
    printfn "Введите путь к файлу: "
    let path = Console.ReadLine()
    
    if IO.File.Exists path then 
        path 
    else 
        printfn "Указанного файла не существует!"
        InputPath ()


let rec FileFill (path:string) = 
    use file = new System.IO.StreamReader(path)

    [
        while not file.EndOfStream do
            file.ReadLine()
    ]

let AddFront sequence symbol =
    let add = string(symbol)
    Seq.map (fun elem -> add + elem) sequence //создание новой последовательности с добавленным элементом в начало

let rec Main () = 
    printfn "Как заполнить последовательность?"
    printfn "1. Ручным заполнением"
    printfn "2. Случайным заполнением"
    printfn "3. Заполнить из файла"
    printfn "----------------------------------------"
    printfn "4. Выйти из программы"
    printfn "\nВыберите действие: "

    let input = Console.ReadLine()
    printfn ""

    if input = "1" then 
        let num = GetN ()
        let posled = List.toSeq (HandFill (num))

        printfn "Сформированная последовательность: "
        PrintOut (posled)

        let posled1 = AddFront posled (AddInput())

        printfn "Результат добавления: "
        PrintOut (posled1) 
        printfn "========================================"

        Main ()
    elif input = "2" then
        let num = GetN ()
        let posled = List.toSeq (RandFill (num))

        printfn "Сформированная последовательность: "
        PrintOut (posled)

        let posled1 = AddFront posled (AddInput())

        printfn "Результат добавления: "
        PrintOut (posled1) 
        printfn "========================================"

        Main ()
    elif input = "3" then 
        let path = InputPath ()

        let posled = List.toSeq (FileFill(path))

        printfn "Сформированная последовательность: "
        PrintOut (posled) 

        let posled1 = AddFront posled (AddInput())

        printfn "Результат добавления: "
        PrintOut (posled1) 
        printfn "========================================"

        Main ()
    elif input = "4" then 
        exit 0
    else 
        printfn "Пожалуйста, выберите действие! \n"
        Main ()

Main ()