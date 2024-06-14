// importing express module
import express from 'express'

// importing controllers
import { 
    getDailyIntakes, 
    getDailyIntake, 
    search, 
    createDailyIntake, 
    deleteDailyIntake, 
    pdateDailyIntake 
} from '../controllers/dailyIntakeController.js'

// creates new router from express module
const router = express.Router();

// defining routes
router.get('/', getDailyIntakes);
router.get('/search/:id', getDailyIntake)
router.get('/search', search)
router.post('/', createDailyIntake)
router.delete('/:id', deleteDailyIntake)
router.put('/:id', updateDailyIntake)

// exports router as default
export default router;


