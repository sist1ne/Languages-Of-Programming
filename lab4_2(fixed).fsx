open System 

type FloatTree = 
    | Node of string * FloatTree * FloatTree
    | Empty

let rec PrintTree tree (space:string) = 
    match tree with 
    | Node (data, left, right)
        -> printfn "%s'%s'" space data
           let addSpace = space + "    "
           PrintTree left addSpace
           PrintTree right addSpace
    | Empty
        -> ()

let rec GetN () = 
    printf "Введите количество элементов для дерева: "
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

let rec AddInput () =  
    printfn "Введите элемент дерева: "
    Console.ReadLine()

let rec AddLeaf (elem:FloatTree) str = 
    match elem with
    | Empty
        -> Node (str, Empty, Empty)

    | Node (value, left, right)
        -> if String.length(value) < String.length(str) then 
                Node(value, (AddLeaf left str), right) 
            else
                Node(value, left, (AddLeaf right str))

let rec HandTree tree size : FloatTree = 
    if size <> 0 then 
        let temp = AddLeaf tree (AddInput())
        HandTree temp (size - 1)
    else
        tree

let RandString () = 
    let alphabet = "abcde fghij klmno pqrst uvwxy zABCD EFGHI JKLMN OPQRS TYVWX YZабв гдеёж зийкл мнопр стуфх цчшщъ ыьэюя АБВГД ЕЁЖЗИ ЙКЛМН ОПРСТ УФХЦЧ ШЩЪЫЬ ЭЮЯ01 23456 789" 
    let alp_size = 154

    let sentence = [
        for i in 1..(Random().Next(1, 15)) do 
            yield alphabet[Random().Next(0, alp_size-1)]
    ]
    String.Concat(sentence)
    
let rec RandTree tree size : FloatTree = 
    if size <> 0 then 
        let randomStr = RandString ()
        let temp = AddLeaf tree randomStr
        RandTree temp (size - 1)
    else
        tree

let finder look_str tree_str acc =
    if look_str = tree_str then 
        acc+1
    else acc

let rec TreeCustomFold func acc tree : int32 = 
    match tree with
    | Empty
        -> acc

    | Node (value, left, right)
        -> 
           let acc = TreeCustomFold func acc left
           let acc = TreeCustomFold func acc right
           func value acc 

let LookInput () =
    printfn "Введите поисковую строку: " 
    Console.ReadLine()

let rec Main () = 
    printfn "Как заполнить последовательность?"
    printfn "1. Ручным заполнением"
    printfn "2. Случайным заполнением"
    printfn "----------------------------------------"
    printfn "3. Выйти из программы"
    printfn "\nВыберите действие: "

    let input = Console.ReadLine()
    printfn ""

    if input = "1" then
        let emptyTree = Empty

        let treeSize = GetN()
        printfn "Первый введенный элемент будет корнем!"
        let tree = HandTree emptyTree treeSize

        printfn "Сформированное дерево: "
        PrintTree tree ""
        
        let str = LookInput ()
        let amount = TreeCustomFold (finder str) 0 tree
        printfn "Результат поиска: %d" amount

        printfn "========================================"

        Main ()
    elif input = "2" then
        let emptyTree = Empty

        let treeSize = GetN()
        printfn "Первый введенный элемент будет корнем!"
        let tree = RandTree emptyTree treeSize

        printfn "Сформированное дерево: "
        PrintTree tree ""

        let str = LookInput ()
        let amount = TreeCustomFold (finder str) 0 tree
        printfn "Результат поиска: %d" amount

        printfn "========================================"

        Main ()
    elif input = "3" then 
        exit 0
    else 
        printfn "Пожалуйста, выберите действие! \n"
        Main ()

Main ()