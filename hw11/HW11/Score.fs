module HW11.Score

let compute (moles: MoleEventStream) (mallets: MalletEventStream) (epochs: uint32 ) = 
    let mole = Seq.toArray (Seq.take (int epochs) moles)
    let mallet = Seq.toArray (Seq.take (int epochs) mallets)
    let rec cnt ep score=
        if ep = epochs then score
        elif ep=0u then 
                    let v1 = match mole.[0] with 
                                            | Popup x->x
                                            | _ -> -1
                    let v2 = match mallet.[0] with 
                                            | Hit x->x
                    if v1=v2 then 
                            mole.[0]<- NothingHappened;
                            cnt (ep+1u) (score+1u)
                    else cnt (ep+1u) score
        elif ep=1u then 
                    let v1 = match mole.[0] with 
                                            | Popup x->x
                                            | _ -> -1
                    let v2 = match mole.[1] with 
                                            | Popup x->x
                                            | _ -> -1
                    let m1 = match mallet.[1] with 
                                            | Hit x->x
                    if m1=v2 then 
                            if v1=v2 then
                                mole.[0]<- NothingHappened;
                                mole.[1]<- NothingHappened;
                                cnt (ep+1u) (score+1u)
                            else
                                mole.[1]<- NothingHappened;
                                cnt (ep+1u) (score+1u)
                    elif m1=v1 then
                            mole.[0]<- NothingHappened;
                            cnt (ep+1u) (score+1u)
                    else cnt (ep+1u) score
        else
            let v1 = match mole.[int ep] with 
                                    | Popup x->x
                                    | _ -> -1
            let v2 = match mole.[int (ep-1u)] with 
                                    | Popup x->x
                                    | _ -> -1
            let v3 = match mole.[int (ep-2u)] with 
                                    | Popup x->x
                                    | _ -> -1
            let m1 = match mallet.[int ep] with 
                                    | Hit x->x
            if  m1=v1 then 
                    if v1=v2 then mole.[int (ep-1u)]<- NothingHappened; 
                                  mole.[int ep]<- NothingHappened;
                                  cnt (ep+1u) (score+1u)
                    else mole.[int ep]<- NothingHappened;
                         cnt (ep+1u) (score+1u)
            elif m1=v2 then
                    mole.[int (ep-1u)]<- NothingHappened;
                    cnt (ep+1u) (score+1u)
            elif m1=v3 then
                    mole.[int (ep-2u)]<- NothingHappened;
                    cnt (ep+1u) (score+1u)
            else cnt (ep+1u) score
    cnt 0u 0u
