// import required from 'joi/lib/types/alternatives/index.js'
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
        type: boolean,
        required: false
    },
    weight: {
        type: Number,
        required: false
    }
})

export const Intake = mongoose.model('Intake', intakeSchema)