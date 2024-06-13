// importing dailyIntake model
import { DailyIntake } from "../models/dailyIntake.js"

// exporting get all method - gets all dailyintakes
export const getDailyIntakes = async (req, res) => {
    try {
        DailyIntake.find()
        .then((dailyIntakes) => {
            // returns status 200 and all dailyIntakes
            res.status(200).json({dailyIntakes: dailyIntakes})
        })
    } catch (error) {
        // return status 500 error if error or no dailyIntakes match
        console.log(error)
        res.status(500).json({msg: "unable to get dailyIntakes"})
    }
}

// exporting get method - gets specific dailyintake through id
export const getDailyIntake = async (req, res) => {
    try {
        const id = req.params.id
        DailyIntake.findById(id)
        .then((dailyIntakes) => {
            // returns status 200 and dailyIntake that matches id
            res.status(200).json({dailyIntake: dailyIntakes})
        })
    } catch (error) {
        // logs and returns status 500 error if failed or no dailyIntakes match
        console.log(error)
        res.status(500).json({msg: "unable to get dailyIntake"})
    }
};

// exporting search method - gets dailyintakes that match criteria
export const search = async (req, res) => {
    try {
        // creates search term from the request query
        const searchTerm = req.query.searchTerm
        
        // creates regex for search
        const searchRegex = new RegExp(searchTerm, "i")
        
        // specifies criteria to search for
        await DailyIntake.find({
            $or : [
                {date: searchRegex}
            ]
        })        
        .then((dailyIntakes) => {
            if(dailyIntakes.lenght){
                console.log(dailyIntakes)
                // returns the dailyIntakes that match
                res.status(200).json({dailyIntakes: dailyIntakes})
            }
            else{
                // return nothing if no dailyIntakes match
                res.status(200).json({dailyIntakes: [], 
                    msg: "no dailyIntakes found"})
            }
        })
    } catch (error) {
        // logs and returns status 500 error if failed
        console.log(error)
        res.status(500).json({msg: "unable to get dailyIntake"})
    }
};

// exporting create method - creates new dailyintake
export const createDailyIntake = async (req, res) => {
    try {
        // creates a dailyIntake from dailyIntake body
        const dailyIntake = new DailyIntake(req.body)

        // saves the new dailyIntake to database
        await dailyIntake.save()
        .then((savedDailyIntakes) => {
            // logs and returns the created dailyIntake
            console.log(savedDailyIntakes)
            res.status(201).json({msg: 'dailyIntake saved', dailyIntake})
        })
    } catch (error) {
        // logs and returns status 500 error if failed
        // dailyIntake not created
        console.log(error)
        res.status(500).json({msg: 'unable to save new dailyIntake'})
    }
    
}

// exporting delete method - deletes a dailyintake through id
export const deleteDailyIntake = async (req, res) => {
    try {
        // gets id from params
        const id = req.params.id

        // deletes the dailyIntake from database
        await DailyIntake.findByIdAndDelete(id)
        .then((dailyIntakes) => {
            // returns the deleted dailyIntake
            res.status(200).json({msg: "Following dailyIntake has been deleted", 
                dailyIntake: dailyIntakes})
        })
    } catch (error) {
        // logs and returns status 500 error if failed 
        // dailyIntake not deleted or couldn't be found
        console.log(error)
        res.status(500).json({msg: "unable to delete dailyIntake"})
    }
}

// exporting update method - updates a dailyintake through id
export const updateDailyIntake = async (req, res) => {
    try {
        // gets id from params
        const id = req.params.id

        // sets new dailyIntake with body  
        const updatedDailyIntake = req.body

        // updates the dailyIntake in database
        await DailyIntake.findOneAndUpdate({_id: id}, 
            updatedDailyIntake, {new: true})
        .then((updatedDailyIntake) => {
            // logs and return the updated dailyIntake
            console.log(updatedDailyIntake)
            res.status(200).json({msg: "dailyIntake updated", 
                dailyIntake: updatedDailyIntake})
        })
    } catch (error) {
        // logs and returns status 500 if error 
        // dailyIntake couldn't be found or couldn't be updated
        console.log(error)
        res.status(500).json({msg: "unable to update dailyIntake"})
    }
}