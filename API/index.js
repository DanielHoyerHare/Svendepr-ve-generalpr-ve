import express from 'express'
import bodyParser from 'body-parser'
import mongoose from 'mongoose'

import userRoutes from './routes/userRoutes.js'
import foodRoutes from './routes/foodRoutes.js'
import dailyIntakeRoutes from './routes/dailyIntakeRoutes.js'
import goalRoutes from './routes/goalRoutes.js'

const app = express();

app.use(bodyParser.json());
app.use(bodyParser.urlencoded({extended : true}));

const dbConnect = async() => {
    try {
        await mongoose.connect('mongodb://0.0.0.0:27017/appDB', {
            autoIndex: true,
        });
        console.log('connected to DB')
    } catch (error) {
        console.log(error)
        process.exit(1)
    }
}

dbConnect();

const PORT = 5000;

app.listen(PORT, () => { console.log(`Listening on port: http://localhost:${PORT}`)})


app.use('/api/users', userRoutes);
app.use('/api/foods', foodRoutes);
app.use('/api/dailyIntakes', dailyIntakeRoutes);
app.use('/api/goals', goalRoutes);

app.get('/', (req, res) => res.send('Hello from homepage'));