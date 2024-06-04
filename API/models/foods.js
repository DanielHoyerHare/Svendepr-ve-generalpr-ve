// import required from 'joi/lib/types/alternatives/index.js'
import mongoose from 'mongoose'

const foodSchema = new mongoose.Schema({
    barcode: {
        type: String,
        required: false
    },
    name: {
        type: String,
        required: false
    },
    godkendt: {
        type: boolean,
        required: false
    },
    calories: {
        type: Number,
        required: false
    },
    carbonhydrates: {
        type: Number,
        required: false
    },
    protein: {
        type: Number,
        required: false
    },
    fat: {
        type: Number,
        required: false
    }
})

export const Food = mongoose.model('Food', foodSchema)