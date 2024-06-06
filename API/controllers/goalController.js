import Goal from "../models/goal.js"


export const getGoals = async (rq, rs) => {
    // Hvis brugeren er admin sendes alle mål
    if (rq.user.admin)
    {
        Goal.find().sort({startDate: -1}).populate('user')
        .then((goals) => {
            rs.status(200).json({goals: goals})
        })
        .catch((error) => {
            console.log(error)
            rs.status(500).json({msg: "unable to get goals"})
        });
    }
    // Hvis brugeren ikke er admin sendes alle deres tidligere mål
    else 
    {
        Goal.find({user: rq.user.id}).sort({startDate: -1})
        .then((goals) => {
            rs.status(200).json({goals: goals})
        })
        .catch((error) => {
            console.log(error)
            rs.status(500).json({msg: "unable to get goals"})
        });
    }
}

// Sender det nuværende mål personen har
export const getGoal = async (rq, rs) => {
    const userId = rq.params.userId
    if (!(rq.user.admin || rq.user.id == userId)) return rs.status(401).json({ message: 'No access' });
    Goal.findOne({user: userId}).sort({startDate: -1})
    .then((goals) => {
        rs.status(200).json({goal: goals})
    })
    .catch((error) => {
        console.log(error)
        rs.status(500).json({msg: "unable to get goal"})
    })
};

// export const search = async (rq, rs) => {
//     try {
//         const searchTerm = rq.query.searchTerm
        
//         const searchRegex = new RegExp(searchTerm, "i")
        
//         await Goal.find({
//             $or : [
                


//                 // Insert




//             ]
//         })
//         .then((goals) => {
//             if(goals.lenght){
//                 console.log(goals)
//                 rs.status(200).json({goals: goals})
//             }
//             else{
//                 rs.status(200).json({goals: [], msg: "no goals found"})
//             }
//         })
//         .catch((error) => {
//             console.log(error)
//             rs.status(500).json({msg: "unable to find goal"})
//         })
//     } catch (error) {
//         console.log(error)
//         rs.status(500).json({msg: "unable to get goal"})
//     }
// };

export const createGoal = async (rq, rs) => {
    if (rq.body.user == null) rq.body.user = rq.user.id;
    if (!(rq.user.admin || rq.user.id == rq.body.user)) return rs.status(401).json({ message: 'No access' });
    rq.body.startDate = new Date().getTime();
    await new Goal(rq.body).save()
    .then((goal) => {
        rs.status(201).json({msg: 'goal saved', goal})
    })
    .catch ((error) => {
        console.log(error)
        rs.status(500).json({msg: 'unable to create new goal'})
    })
}

export const deleteGoal = async (rq, rs) => {
    try {
        const id = rq.params.id

        await Goal.findByIdAndDelete(id)
        .then((goals) => {
            rs.status(200).json({msg: "Following goal has been deleted", goal: goals})
        })
        .catch((error) => {
            console.log(error)
            rs.status(500).json({msg: "unable to get goal"})
        })
    } catch (error) {
        console.log(error)
        rs.status(500).json({msg: "unable to get goal"})
    }
}

export const updateGoal = async (rq, rs) => {
    try {
        const id = rq.params.id
        const updatedGoal = rq.body

        await Goal.findOneAndUpdate({_id: id}, updatedGoal, {new: true})
        .then((updatedGoal) => {
            console.log(updatedGoal)
            rs.status(200).json({msg: "goal updated", goal: updatedGoal})
        })
        .catch((error) => {
            console.log(error)
            rs.status(500).json({msg: "unable to update goal"})
        })
    } catch (error) {
        console.log(error)
        rs.status(500).json({msg: "unable to update goal"})
    }
}