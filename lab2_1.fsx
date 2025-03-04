open System 

printfn "Добро пожаловать! \nЭта программа добавляет в начало каждого элемента списка заданный символ!"

//рекурсивная функция для Диалога с пользователем
let rec Menu () = 
    printfn "\nКак заполнить список?"
    printfn "1. Ручным заполнением"
    printfn "2. Случайным заполнением"
    printfn "----------------------------------------"
    printfn "3. Выйти из программы"
    printfn "\nВыберите действие: "

    let line = Console.ReadLine()

    if line = "1" then 1
    elif line = "2" then 2 
    elif line = "3" then 3
    else 
        printfn "Пожалуйста, выберите действие! \n"
        Menu ()

//рекурсивная функция для Запроса и хранения записанного пользователем символа
let rec AddInput () =  
    printfn "\nВведите символ, который хотите добавить в начало каждого элемента: "
    let succ, res = Char.TryParse(Console.ReadLine())

    if succ = true then 
        res
    else 
        printfn "Введите один символ!"
        AddInput ()

//рекурсивная функция для Запроса и хранения записанного пользователем количества элементов
let rec N () = 
    printf "Введите количество элементов для списка: "
    let succ, res = Int32.TryParse(Console.ReadLine())

    if succ = true then 
        if (res >= 0) then 
            res
        else 
            printfn "Количество элементов не может быть отрицательным! \n"
            N ()
    else 
        printfn "Пожалуйста, введите число! \n"
        N ()

//функция для вывода списка
let Print (spisok) = 
    printf "%A" spisok

//функция для ручного заполнения списка, возвращающая заполненный список
let HandZ (n) =
    [
        for i in 1..n do 
            printf "Введите %d элемент списка: " i
            yield Console.ReadLine()
    ]

let alphabet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTYVWXYZабвгдеёжзийклмнопрстуфхцчшщъыьэюяАБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ0123456789" 
let alp_size = 128

//функция для случайного заполнения списка, возвращающая заполненный список
let RandZ (n) =
    [
        for i in 1..n do                                            //цикл для заполнения списка из строк 
            let sentence_size = Random().Next(1, 6)

            let sentence = [                            //список из слов
                for j in 1..sentence_size do                        //цикл для заполнения списка из слов 
                    let word_size = Random().Next(1, 6)
                    let word = [                        //список из букв
                        for k in 1..word_size do                    //цикл для заполнения списка из символов 
                            let temp = Random().Next(0, alp_size-1) 
                            yield alphabet[temp]
                    ]
                    yield String.Concat(word)       //преобразование списка из букв в тип данных string и добавление в список из слов
            ]
            yield String.Join(" ", sentence)       //преобразование списка из слов в строку с разделителями и добавление в список из строк
    ]

//функция для добавления символа в начало каждого элемента списка
let AddFront (theList:string list) (symbol:char) = 
    let add = string(symbol)
    List.map (fun el -> add + el) theList

//рекурисвная функция для цикличной работы программы
let rec CycleWork () =
    let temp = Menu ()

    if temp = 1 then
        let num = N ()
        let spisok = HandZ (num)
        printf "\nСформированный список: "
        Print (spisok)

        let spisok1 = AddFront spisok (AddInput ())  //сохранение изменненного списка с добавлением символа в начале каждого элемента

        printf "\nРезультат добавления: "
        Print (spisok1) 
        printf "\n========================================"

        CycleWork () 

    elif temp = 2 then 
        let num = N ()
        let spisok = RandZ (num)
        printf "\nСформированный список: "
        Print (spisok)

        let spisok1 = AddFront spisok (AddInput ())  //сохранение изменненного списка с добавлением символа в начале каждого элемента

        printf "\nРезультат добавления: "
        Print (spisok1) 
        printf "\n========================================"

        CycleWork () 

    elif temp = 3 then
        exit 0 

let main = 
    CycleWork ()

    0