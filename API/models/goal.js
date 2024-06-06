// import required from 'joi/lib/types/alternatives/index.js'
import mongoose from 'mongoose'

const goalSchema = new mongoose.Schema({
    startDate: {
        type: Date,
        required: false
    },
    userID: {
        type: String,
        required: true
    },
    calorieGoal: {
        type: Number,
        required: false
    },
    carbonhydratesGoal: {
        type: Number,
        required: false
    },
    proteinGoal: {
        type: Number,
        required: false
    },
    fatGoal: {
        type: Number,
        required: false
    }
})

export const Goal = mongoose.model('Goal', goalSchema)