using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03251
{
    internal class Test
    {
        private double frequency; // 正弦波的频率
        private double amplitude; // 正弦波的振幅
        private double sampleRate; // 采样率
        private double currentTime; // 当前时间

        public Test(double frequency, double amplitude, double sampleRate)
        {
            this.frequency = frequency;
            this.amplitude = amplitude;
            this.sampleRate = sampleRate;
            this.currentTime = 0.0;
        }
        public double GenerateNextY()
        {
            double y = Math.Sin(2 * Math.PI * frequency * currentTime) * amplitude; // 正弦波在y轴上的值

            currentTime += 1.0 / sampleRate; // 更新当前时间

            return y;
        }
    }
}