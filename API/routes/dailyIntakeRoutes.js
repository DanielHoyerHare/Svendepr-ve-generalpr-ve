// importing express module
import express from 'express'

// importing controllers
import { 
    getDailyIntakes, 
    getDailyIntake, 
    search, 
    createDailyIntake, 
    deleteDailyIntake, 
    updateDailyIntake 
} from '../controllers/dailyIntakeController.js'
import { authenticate } from '../middlewares/Authenticator.js';

// creates new router from express module
const router = express.Router();

// defining routes
router.get('/', authenticate, getDailyIntakes);
router.get('/search/:id', authenticate, getDailyIntake)
router.get('/search', authenticate, search)
router.post('/', authenticate, createDailyIntake)
router.delete('/:id', authenticate, deleteDailyIntake)
router.put('/:id', authenticate, updateDailyIntake)

// exports router as default
export default router;


