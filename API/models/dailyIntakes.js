// import required from 'joi/lib/types/alternatives/index.js'
import mongoose from 'mongoose'

const intakeSchema = new mongoose.Schema({
    // id: {
    //     type: String,
    //     required: true
    // },
    dato: {
        type: Date,
        required: false
    },
    brugerID: {
        type: String,
        required: true
    },
    fødevarerID: {
        type: boolean,
        required: false
    },
    vægt: {
        type: Number,
        required: false
    }
})

export const Intake = mongoose.model('Intake', intakeSchema)