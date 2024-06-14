import express from 'express'
import bodyParser from 'body-parser'
import mongoose from 'mongoose'

import authRoutes from './routes/authRoutes.js';
import userRoutes from './routes/userRoutes.js'
import foodRoutes from './routes/foodRoutes.js'
import dailyIntakeRoutes from './routes/dailyIntakeRoutes.js'
import goalRoutes from './routes/goalRoutes.js'

process.env.SECRET_KEY = 'test';
process.env.MONGODB_URL = 'mongodb://0.0.0.0:27017/appDB';
process.env.PORT = 5000;

const app = express();

app.use(bodyParser.json());
app.use(bodyParser.urlencoded({extended : true}));

//Connection to MongoDB through mongooose

const dbConnect = async() => {
    try {
        await mongoose.connect(process.env.MONGODB_URL, {
            autoIndex: true,
        });
        console.log('connected to DB')
    } catch (error) {
        console.log(error)
        process.exit(1)
    }
}

dbConnect();

app.listen(process.env.PORT, () => 
    { console.log(`Listening on port: http://localhost:${process.env.PORT}`)})

app.use('/api/auth', authRoutes);
app.use('/api/users', userRoutes);
app.use('/api/foods', foodRoutes);
app.use('/api/dailyIntakes', dailyIntakeRoutes);
app.use('/api/goals', goalRoutes);

app.get('/', (req, res) => res.send('Hello from homepage'));