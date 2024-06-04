import {v4 as uuidv4} from 'uuid';

import { DailyIntake } from "../models/dailyIntakes"


export const getDailyIntakes = async (req, res) => {
    try {
        DailyIntake.find()
        .then((dailyIntakes) => {
            res.status(200).json({dailyIntakes: dailyIntakes})
        })
        .catch((error) => {
            console.log(error)
            res.status(500).json({msg: "unable to get dailyIntakes"})
        })
    } catch (error) {
        console.log(error)
        res.status(500).json({msg: "unable to get dailyIntakes"})
    }
}

export const getDailyIntake = async (req, res) => {
    try {
        const id = req.params.id
        DailyIntake.findById(id)
        .then((dailyIntakes) => {
            res.status(200).json({dailyIntake: dailyIntakes})
        })
        .catch((error) => {
            console.log(error)
            res.status(500).json({msg: "unable to get dailyIntake"})
        })
    } catch (error) {
        console.log(error)
        res.status(500).json({msg: "unable to get dailyIntake"})
    }
};

export const search = async (req, res) => {
    try {
        const searchTerm = req.query.searchTerm
        
        const searchRegex = new RegExp(searchTerm, "i")
        
        await DailyIntake.find({
            $or : [
                


                // Insert




            ]
        })
        .then((dailyIntakes) => {
            if(dailyIntakes.lenght){
                console.log(dailyIntakes)
                res.status(200).json({dailyIntakes: dailyIntakes})
            }
            else{
                res.status(200).json({dailyIntakes: [], msg: "no dailyIntakes found"})
            }
        })
        .catch((error) => {
            console.log(error)
            res.status(500).json({msg: "unable to find dailyIntake"})
        })
    } catch (error) {
        console.log(error)
        res.status(500).json({msg: "unable to get dailyIntake"})
    }
};

export const createDailyIntake = async (req, res) => {
    try {
        const dailyIntake = new DailyIntake(req.body)
        await dailyIntake.save()
        .then((savedDailyIntakes) => {
            console.log(savedDailyIntakes)
            res.status(201).json({msg: 'dailyIntake saved', dailyIntake})
        })
        .catch ((error) => {
            console.log(error)
            res.status(500).json({msg: 'unable to create new dailyIntake', dailyIntake})
        })
    } catch (error) {
        console.log(error)
        res.status(500).json({msg: 'unable to save new dailyIntake'})
    }
    
}

export const deleteDailyIntake = async (req, res) => {
    try {
        const id = req.params.id

        await DailyIntake.findByIdAndDelete(id)
        .then((dailyIntakes) => {
            res.status(200).json({msg: "Following dailyIntake has been deleted", dailyIntake: dailyIntakes})
        })
        .catch((error) => {
            console.log(error)
            res.status(500).json({msg: "unable to get dailyIntake"})
        })
    } catch (error) {
        console.log(error)
        res.status(500).json({msg: "unable to get dailyIntake"})
    }
}

export const updateDailyIntake = async (req, res) => {
    try {
        const id = req.params.id
        const updatedDailyIntake = req.body

        await DailyIntake.findOneAndUpdate({_id: id}, updatedDailyIntake, {new: true})
        .then((updatedDailyIntake) => {
            console.log(updatedDailyIntake)
            res.status(200).json({msg: "dailyIntake updated", dailyIntake: updatedDailyIntake})
        })
        .catch((error) => {
            console.log(error)
            res.status(500).json({msg: "unable to update dailyIntake"})
        })
    } catch (error) {
        console.log(error)
        res.status(500).json({msg: "unable to update dailyIntake"})
    }
}