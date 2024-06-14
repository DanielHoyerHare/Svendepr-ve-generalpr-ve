// importing express module
import express from 'express'

// importing authentcate 
import { authenticate } from '../middlewares/Authenticator.js';

// importing controllers
import { 
    getGoals, 
    getGoal, 
    search,
    createGoal, 
    deleteGoal, 
    updateGoal 
} from '../controllers/goalController.js'

// creates new router from express module
const router = express.Router();


// defining post routes
router.get('/', authenticate, getGoals);
router.get('/:userId', authenticate, getGoal)
router.get('/search', authenticate, search)
router.post('/', authenticate, createGoal)
router.delete('/:id', authenticate, deleteGoal)
router.put('/:id', authenticate, updateGoal)

// exporting router as default
export default router;


