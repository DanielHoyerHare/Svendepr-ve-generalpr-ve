import { Food } from "../models/food.js"


export const getFoods = async (req, res) => {
    try {
        Food.find()
        .then((foods) => {
            res.status(200).json({foods: foods})
        })
        .catch((error) => {
            console.log(error)
            res.status(500).json({msg: "unable to get foods"})
        })
    } catch (error) {
        console.log(error)
        res.status(500).json({msg: "unable to get foods"})
    }
}

export const getFood = async (req, res) => {
    try {
        const id = req.params.id
        Food.findById(id)
        .then((foods) => {
            res.status(200).json({food: foods})
        })
        .catch((error) => {
            console.log(error)
            res.status(500).json({msg: "unable to get food"})
        })
    } catch (error) {
        console.log(error)
        res.status(500).json({msg: "unable to get food"})
    }
};

export const search = async (req, res) => {
    try {
        const searchTerm = req.query.searchTerm
        
        const searchRegex = new RegExp(searchTerm, "i")
        
        await Food.find({
            $or : [
                {name: searchRegex},
                {calories: searchRegex},
                {fat: searchRegex},
                {carbonhydrates: searchRegex}
            ]
        })
        .then((foods) => {
            if(foods.lenght){
                console.log(foods)
                res.status(200).json({foods: foods})
            }
            else{
                res.status(200).json({foods: [], msg: "no foods found"})
            }
        })
        .catch((error) => {
            console.log(error)
            res.status(500).json({msg: "unable to find food"})
        })
    } catch (error) {
        console.log(error)
        res.status(500).json({msg: "unable to get food"})
    }
};

export const createFood = async (req, res) => {
    try {
        const food = new Food(req.body)
        await food.save()
        .then((savedFoods) => {
            console.log(savedFoods)
            res.status(201).json({msg: 'food saved', food})
        })
        .catch ((error) => {
            console.log(error)
            res.status(500).json({msg: 'unable to create new food', food})
        })
    } catch (error) {
        console.log(error)
        res.status(500).json({msg: 'unable to save new food'})
    }
    
}

export const deleteFood = async (req, res) => {
    try {
        const id = req.params.id

        await Food.findByIdAndDelete(id)
        .then((foods) => {
            res.status(200).json({msg: "Following food has been deleted", food: foods})
        })
        .catch((error) => {
            console.log(error)
            res.status(500).json({msg: "unable to get food"})
        })
    } catch (error) {
        console.log(error)
        res.status(500).json({msg: "unable to get food"})
    }
}

export const updateFood = async (req, res) => {
    try {
        const id = req.params.id
        const updatedFood = req.body

        await Food.findOneAndUpdate({_id: id}, updatedFood, {new: true})
        .then((updatedFood) => {
            console.log(updatedFood)
            res.status(200).json({msg: "food updated", food: updatedFood})
        })
        .catch((error) => {
            console.log(error)
            res.status(500).json({msg: "unable to update food"})
        })
    } catch (error) {
        console.log(error)
        res.status(500).json({msg: "unable to update food"})
    }
}