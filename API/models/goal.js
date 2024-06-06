import mongoose from 'mongoose'

const goalSchema = new mongoose.Schema({
    userId: {
        type: mongoose.Schema.Types.ObjectId,
        ref: "userProfile"
    },
    startDate: {
        type: Date,
        required: false
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