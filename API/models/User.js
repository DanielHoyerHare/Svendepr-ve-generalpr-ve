import mongoose from 'mongoose';
import bcrypt from 'bcrypt';

const userSchema = new mongoose.Schema({
    username: {
        type: String,
        required: [true, 'Username is required'],
        minLength: 3,
        trim: true,
        validate: {
            validator: function(value){
                const regex = /^[a-zA-ZæøåÆØÅ0-9]*$/;
                return regex.test(value);
            },
            message: 'Username can only contain letters and numbers'
        }
    },
    email: {
        type: String,
        required: [true, 'Email is required'],
        minLength: 3,
        unique: true,
        validate: {
            validator: function(value){
                const regex = /^(([^<>()[\]\\.,;:\s@']+(\.[^<>()[\]\\.,;:\s@']+)*)|.('.+'))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
                return regex.test(value);
            },
            message: 'Provided email is not valid'
        }
    },
    password: {
        type: String,
        required: [true, 'Password is required']
    },
    age: {
        type: Number,
        required: false,
        default: null
    },
    weight: {
        type: Number,
        required: false,
        default: null
    },
    height: {
        type: Number,
        required: false,
        default: null
    },
    admin: {
        type: Boolean,
        required: false,
        default: false
    }
});

userSchema.pre('save', async function (next) {
    const user = this;
    if (!user.isModified('password')) return next();

    try {
        const salt = await bcrypt.genSalt();
        user.password = await bcrypt.hash(user.password, salt);
        next();
    } catch (err){
        return next(err);
    }
});

userSchema.methods.comparePassword = async function (password) {
    return bcrypt.compare(password,this.password)
}

const model = mongoose.model('User', userSchema);

// export const schema = model.schema;
export default model;