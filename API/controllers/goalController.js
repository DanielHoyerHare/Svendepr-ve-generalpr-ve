import { Goal } from "../models/goals.js"


export const getGoals = async (req, res) => {
    try {
        Goal.find()
        .then((goals) => {
            res.status(200).json({goals: goals})
        })
        .catch((error) => {
            console.log(error)
            res.status(500).json({msg: "unable to get goals"})
        })
    } catch (error) {
        console.log(error)
        res.status(500).json({msg: "unable to get goals"})
    }
}

export const getGoal = async (req, res) => {
    try {
        const id = req.params.id
        Goal.findById(id)
        .then((goals) => {
            res.status(200).json({goal: goals})
        })
        .catch((error) => {
            console.log(error)
            res.status(500).json({msg: "unable to get goal"})
        })
    } catch (error) {
        console.log(error)
        res.status(500).json({msg: "unable to get goal"})
    }
};

export const search = async (req, res) => {
    try {
        const searchTerm = req.query.searchTerm
        
        const searchRegex = new RegExp(searchTerm, "i")
        
        await Goal.find({
            $or : [
                


                // Insert




            ]
        })
        .then((goals) => {
            if(goals.lenght){
                console.log(goals)
                res.status(200).json({goals: goals})
            }
            else{
                res.status(200).json({goals: [], msg: "no goals found"})
            }
        })
        .catch((error) => {
            console.log(error)
            res.status(500).json({msg: "unable to find goal"})
        })
    } catch (error) {
        console.log(error)
        res.status(500).json({msg: "unable to get goal"})
    }
};

export const createGoal = async (req, res) => {
    try {
        const goal = new Goal(req.body)
        await goal.save()
        .then((savedGoals) => {
            console.log(savedGoals)
            res.status(201).json({msg: 'goal saved', goal})
        })
        .catch ((error) => {
            console.log(error)
            res.status(500).json({msg: 'unable to create new goal', goal})
        })
    } catch (error) {
        console.log(error)
        res.status(500).json({msg: 'unable to save new goal'})
    }
    
}

export const deleteGoal = async (req, res) => {
    try {
        const id = req.params.id

        await Goal.findByIdAndDelete(id)
        .then((goals) => {
            res.status(200).json({msg: "Following goal has been deleted", goal: goals})
        })
        .catch((error) => {
            console.log(error)
            res.status(500).json({msg: "unable to get goal"})
        })
    } catch (error) {
        console.log(error)
        res.status(500).json({msg: "unable to get goal"})
    }
}

export const updateGoal = async (req, res) => {
    try {
        const id = req.params.id
        const updatedGoal = req.body

        await Goal.findOneAndUpdate({_id: id}, updatedGoal, {new: true})
        .then((updatedGoal) => {
            console.log(updatedGoal)
            res.status(200).json({msg: "goal updated", goal: updatedGoal})
        })
        .catch((error) => {
            console.log(error)
            res.status(500).json({msg: "unable to update goal"})
        })
    } catch (error) {
        console.log(error)
        res.status(500).json({msg: "unable to update goal"})
    }
}