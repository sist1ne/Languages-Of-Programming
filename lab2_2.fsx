open System 

printfn "Добро пожаловать! \nЭта программа ищет количество элементов с заданной пользователем длинной."

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

//рекурсивная функция для Запроса и хранения записанной пользователем длины строки
let rec LenghtInput () =  
    printfn "\nВведите поисковое количество символов в элементе списка: "
    let succ, res = Int32.TryParse(Console.ReadLine())

    if succ = true then 
        if (res >= 0) then 
            res
        else 
            printfn "Длина не может быть меньше нуля!"
            LenghtInput ()
    else 
        printfn "Пожалуйста, введите число!"
        LenghtInput ()

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

//функция для поиска количества элементов с заданной длиной
let SearchLenght (theList:string list) (lenght:int) = 
    List.fold 
        (fun acc stroka -> 
            //проверка на соответствие длины элемента списка и заданной пользователем длины
            if String.length stroka = lenght then 
                acc + 1 
            else acc
        ) 
        0 theList

//рекурисвная функция для цикличной работы программы
let rec CycleWork () =
    let temp = Menu ()

    if temp = 1 then
        let num = N ()
        let spisok = HandZ (num)
        printf "\nСформированный список: "
        Print (spisok)

        let size = LenghtInput ()
        let result = SearchLenght spisok size //сохранение количества элементов списка с заданной пользователем длиной

        printfn "Количество элементов списка с длиной %d: %d" size result 
        printf "========================================"

        CycleWork () 

    elif temp = 2 then 
        let num = N ()
        let spisok = RandZ (num)
        printf "\nСформированный список: "
        Print (spisok)

        let size = LenghtInput ()
        let result = SearchLenght spisok size //сохранение количества элементов списка с заданной пользователем длиной

        printfn "Количество элементов списка с длиной %d: %d" size result 
        printf "========================================"

        CycleWork () 

    elif temp = 3 then
        exit 0 

let main = 
    CycleWork ()

    0