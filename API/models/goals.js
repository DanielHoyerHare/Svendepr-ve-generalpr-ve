// import required from 'joi/lib/types/alternatives/index.js'
import mongoose from 'mongoose'

const goalSchema = new mongoose.Schema({
    // id: {
    //     type: String,
    //     required: true
    // },
    startDato: {
        type: Date,
        required: false
    },
    brugerID: {
        type: String,
        required: true
    },
    godkendt: {
        type: boolean,
        required: false
    },
    kalorierMål: {
        type: Number,
        required: false
    },
    kulhydraterMål: {
        type: Number,
        required: false
    },
    proteinMål: {
        type: Number,
        required: false
    },
    fedtMål: {
        type: Number,
        required: false
    }
})

export const Goal = mongoose.model('Goal', goalSchema)