// import required from 'joi/lib/types/alternatives/index.js'
import mongoose from 'mongoose'

const userSchema = new mongoose.Schema({
    // id: {
    //     type: String,
    //     required: true
    // },
    rolle: {
        type: String,
        required: false
    },
    usersame: {
        type: String,
        required: false
    },
    email: {
        type: String,
        required: false
    },
    password: {
        type: String,
        required: false
    },
    alder: {
        type: Number,
        required: false
    },
    vægt: {
        type: Number,
        required: false
    },
    højde: {
        type: Number,
        required: false
    }
})

export const User = mongoose.model('User', userSchema)