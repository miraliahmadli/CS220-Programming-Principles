module HW3.MySolution

// FIXME
let rec prob1 n = 
    if n<1 then nan
    elif n=1 then 1.0
    else prob1(n-1) + (1.0/float n)

// FIXME
let prob2 amount = 
    let coins = [1; 10; 50; 100; 500]
    let rec CountCombinations (coin: int list) (numElem:int) (amount:int)= 
        if amount<0 then 0
        elif amount=0 then 1
        elif numElem<=0 then 0
        else (CountCombinations coin numElem (amount-coin.[numElem-1])) +  (CountCombinations coin (numElem-1) amount)
    if amount<0 then -1
    elif amount=0 then 0
    else CountCombinations coins 5 amount
        

// FIXME
let rec prob3 a b = 
    let rec gcd a b =
        if b=0 then a
        else gcd b (a%b)
    if a=0 && b=0 then 0 ///why
    elif a<0 then prob3 (abs a) b
    elif b<0 then prob3 a (abs b)
    elif a<b then gcd b a
    else gcd a b

// FIXME
let prob4 n = 
    let rec func sum counter max =
        if counter > max then sum
        elif  2147483647-sum < counter then -1
        else func (sum+counter) (counter+1) max
    if n < 0 then -1
    else func 0 0 n

// FIXME
let prob5 m n = 
    let rec func sum counter max =
        if counter > max then sum
        elif  2147483647-sum < counter then -1
        else func (sum+counter) (counter+1) max
    let rec funcNeg sum counter max =
        if counter > max then sum
        elif  -2147483648-sum > counter then -1
        else func (sum+counter) (counter+1) max
    if n<0 then -1
    elif n=0 then m
    elif m<0 then
        if m+n>0 then 
            if (m+n)=(abs m) then 0
            elif (m+n)>(abs m) then func 0 (-m+1) (m+n)
            else funcNeg 0 m (-(m+n)-1)
        else funcNeg 0 m (m+n)
    else func 0 m (m+n)