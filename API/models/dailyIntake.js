import mongoose from 'mongoose'

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

export const DailyIntake = mongoose.model('DailyIntake', intakeSchema)