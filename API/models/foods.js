// import required from 'joi/lib/types/alternatives/index.js'
import mongoose from 'mongoose'

const foodSchema = new mongoose.Schema({
    // id: {
    //     type: String,
    //     required: true
    // },
    stregkode: {
        type: String,
        required: false
    },
    navn: {
        type: String,
        required: false
    },
    godkendt: {
        type: boolean,
        required: false
    },
    kalorier: {
        type: Number,
        required: false
    },
    kulhydrater: {
        type: Number,
        required: false
    },
    protein: {
        type: Number,
        required: false
    },
    fedt: {
        type: Number,
        required: false
    }
})

export const Food = mongoose.model('Food', foodSchema)