// imports mongoose to use to create schema
import mongoose from 'mongoose'

// creates schema
const intakeSchema = new mongoose.Schema({
    date: {
        type: Date,
        required: false
    },
    userID: {
        type: String,
        required: true
    },
    foodID: {
        type: String,
        required: false
    },
    weight: {
        type: Number,
        required: false
    }
})

// exports scheme as model to mongoose database and controllers
export const DailyIntake = mongoose.model('DailyIntake', intakeSchema)