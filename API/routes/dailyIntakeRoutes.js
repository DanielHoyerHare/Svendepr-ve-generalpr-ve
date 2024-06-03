import express from 'express'
import { getDailyIntakes, getDailyIntake, search, createDailyIntake, deleteDailyIntake, updateDailyIntake } from '../controllers/carController.js'

const router = express.Router();

router.get('/', getDailyIntakes);

router.get('/search/:id', getDailyIntake)

router.get('/search', search)

router.post('/', createDailyIntake)

router.delete('/:id', deleteDailyIntake)

router.put('/:id', updateDailyIntake)

export default router;