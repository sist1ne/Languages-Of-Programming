open System

type FloatTree = 
    | Node of float * FloatTree * FloatTree
    | Empty

let rec PrintTree tree (space:string) = 
    match tree with 
    | Node (data, left, right)
        -> printfn "%s%.3f" space data
           let addSpace = space + "    "
           PrintTree left addSpace
           PrintTree right addSpace
    | Empty
        -> ()

let rec PrintTree1 tree (space:string) = 
    match tree with 
    | Node (data, left, right)
        -> printfn "%s%.0f" space data
           let addSpace = space + "    "
           PrintTree1 left addSpace
           PrintTree1 right addSpace
    | Empty
        -> ()

let rec GetN () = 
    printf "������� ���������� ��������� ��� ������: "
    let succ, res = Int32.TryParse(Console.ReadLine())

    if succ = true then 
        if (res >= 0) then 
            res
        else 
            printfn "���������� ��������� �� ����� ���� �������������! \n"
            GetN ()
    else 
        printfn "����������, ������� �����! \n"
        GetN ()

let rec AddInput () =  
    printfn "������� ������� ������: "
    let succ, res = Double.TryParse(Console.ReadLine())

    if succ = true then 
        res
    else 
        printfn "������� �����!"
        AddInput ()

let rec AddLeaf (elem:FloatTree) num = 
    match elem with
    | Empty
        -> Node (num, Empty, Empty)

    | Node (value, left, right)
        -> if value < num then 
                Node(value, (AddLeaf left num), right) 
            else
                Node(value, left, (AddLeaf right num))

let rec HandTree tree size : FloatTree = 
    if size <> 0 then 
        let temp = AddLeaf tree (AddInput())
        HandTree temp (size - 1)
    else
        tree

let rec RandTree tree size : FloatTree = 
    if size <> 0 then 
        let randomNum = float(Random().Next(1, 500)) + 0.001 * float(Random().Next(1, 100))
        let temp = AddLeaf tree randomNum
        RandTree temp (size - 1)
    else
        tree

let rec LeastDigit num lowest = 
    if (lowest = 0) || (num < 1) then 
        float(lowest)
    else 
        if num % 10 < lowest then 
            LeastDigit (num/10) (num%10)
        else 
            LeastDigit(num/10) lowest

let rec RoundLeaf (tree:FloatTree) = 
    match tree with 
    | Node (data, left, right)
        ->
            let temp = int(Math.Ceiling(data))
            
            let res =
                if temp = 0 then 
                    float(temp)
                else if temp < 0 then 
                    float(LeastDigit (temp*(-1)) 9)
                else
                    float(LeastDigit temp 9)

            Node(res, RoundLeaf(left), RoundLeaf(right))
    | Empty
        -> Empty

let rec TreeCustomMap func tree = 
    let emptyTree = Empty 
    func tree

let rec Main () = 
    printfn "��� ��������� ������������������?"
    printfn "1. ������ �����������"
    printfn "2. ��������� �����������"
    printfn "----------------------------------------"
    printfn "3. ����� �� ���������"
    printfn "\n�������� ��������: "

    let input = Console.ReadLine()
    printfn ""

    if input = "1" then
        let emptyTree = Empty

        let treeSize = GetN()
        printfn "������ ��������� ������� ����� ������!"
        let tree = HandTree emptyTree treeSize

        printfn "�������������� ������: "
        PrintTree tree ""

        let tree1 = TreeCustomMap RoundLeaf tree
        printfn "\n������ � ������������ ����������: "

        PrintTree1 tree1 ""
        printfn "========================================"

        Main ()
    elif input = "2" then
        let emptyTree = Empty

        let treeSize = GetN()
        printfn "������ ��������� ������� ����� ������!"
        let tree = RandTree emptyTree treeSize

        printfn "�������������� ������: "
        PrintTree tree ""

        let tree1 = TreeCustomMap RoundLeaf tree
        printfn "\n������ � ������������ ����������: "

        PrintTree1 tree1 ""
        printfn "========================================"

        Main ()
    elif input = "3" then 
        exit 0
    else 
        printfn "����������, �������� ��������! \n"
        Main ()

Main ()