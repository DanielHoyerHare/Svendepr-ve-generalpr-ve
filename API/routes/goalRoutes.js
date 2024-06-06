import express from 'express'
import { getGoals, getGoal, createGoal, deleteGoal, updateGoal } from '../controllers/goalController.js'
import { authenticate } from '../middlewares/Authenticator.js';

const router = express.Router();

router.get('/', authenticate, getGoals);

router.get('/:userId', authenticate, getGoal)

// router.get('/search', authenticate, search)

router.post('/', authenticate, createGoal)

router.delete('/:id', authenticate, deleteGoal)

router.put('/:id', authenticate, updateGoal)

export default router;