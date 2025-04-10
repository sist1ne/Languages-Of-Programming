open System

printfn "Добро пожаловать! \nЭта программа добавляет в начало каждого элемента списка заданный символ."

let rec AddInput () =  
    printfn "\nВведите символ, который хотите добавить в начало каждого элемента: "
    let succ, res = Char.TryParse(Console.ReadLine())

    if succ = true then 
        res
    else 
        printfn "Введите один символ!"
        AddInput ()

let rec GetN () = 
    printf "Введите количество элементов для списка: "
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

let Print (spisok) = 
    printf "%A" spisok

let HandFill (n) =
    [
        for i in 1..n do 
            printf "Введите %d элемент списка: " i
            yield Console.ReadLine()
    ]

let alphabet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTYVWXYZабвгдеёжзийклмнопрстуфхцчшщъыьэюяАБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ0123456789" 
let alp_size = 128

let GenerateWord (size) =
    [                        //список из букв
        for i in 1..size do                    //цикл для заполнения списка из символов 
            let temp = Random().Next(0, alp_size-1) 
            yield alphabet[temp]
    ]

let GenerateSentence (size) = 
    [                            
        for i in 1..size do                        
            let word_size = Random().Next(1, 6)
            yield String.Concat(GenerateWord (word_size))
    ]

let RandFill (n) =
    [
        for i in 1..n do
            let sent_size = Random().Next(1, 6)

            let sentence = GenerateSentence (sent_size)
            yield String.Join(" ", sentence)
    ]

let AddFront (theList:string list) (symbol:char) = 
    let add = string(symbol)
    List.map (fun elem -> add + elem) theList

let rec Main () = 
    printfn "\nКак заполнить список?"
    printfn "1. Ручным заполнением"
    printfn "2. Случайным заполнением"
    printfn "----------------------------------------"
    printfn "3. Выйти из программы"
    printfn "\nВыберите действие: "

    let input = Console.ReadLine()

    if input = "1" then 
        let num = GetN ()
        let spisok = HandFill (num)
        printf "\nСформированный список: "
        Print (spisok)

        let spisok1 = AddFront spisok (AddInput ())

        printf "\nРезультат добавления: "
        Print (spisok1) 
        printf "\n========================================"

        Main ()
    elif input = "2" then 
        let num = GetN ()
        let spisok = RandFill (num)
        printf "\nСформированный список: "
        Print (spisok)

        let spisok1 = AddFront spisok (AddInput ())

        printf "\nРезультат добавления: "
        Print (spisok1) 
        printf "\n========================================"

        Main ()
    elif input = "3" then 
        exit 0
    else 
        printfn "Пожалуйста, выберите действие! \n"
        Main ()

Main ()