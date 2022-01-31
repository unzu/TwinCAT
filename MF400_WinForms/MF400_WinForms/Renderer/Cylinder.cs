using GlmNet;
using System.Diagnostics;

namespace MF400_Winforms.Renderer
{
    internal class Cylinder : Mesh
    {
        private const uint DIVISIONS = 8;
        private const uint CALCS = DIVISIONS / 4;
        private const uint CALCS2 = CALCS * 2;
        private const uint CALCS3 = CALCS * 3;
        private const uint CALCS4 = CALCS * 4;
        private const uint CALCS5 = CALCS * 5;
        private const uint CALCS6 = CALCS * 6;
        private const uint CALCS7 = CALCS * 7;
        private const uint CALCS8 = CALCS * 8;
        private const uint CALCS9 = CALCS * 9;
        private const uint CALCS10 = CALCS * 10;
        private const uint CALCS11 = CALCS * 11;
        private const uint CALCS12 = CALCS * 12;
        private const uint CALCS13 = CALCS * 13;
        private const uint CALCS14 = CALCS * 14;
        private const uint CALCS15 = CALCS * 15;
        private const uint CALCS16 = CALCS * 16;
        private const uint CALCS24 = CALCS * 24;
        private const uint CALCS36 = CALCS * 36;
        private const uint CALCS48 = CALCS * 48;
        private const uint CALCS60 = CALCS * 60;
        private const uint CALCS72 = CALCS * 72;
        private const uint CALCS84 = CALCS * 84;
        private const uint CALCS96 = CALCS * 96;

        private static bool initialized = false;
        private static float[] positionsUnitCircle = new float[CALCS];
        private static uint[] indices = new uint[CALCS96];

        private Vertex[] positionsCylinder = new Vertex[CALCS16];

        private float _r1;
        private float _r2;
        private float _h;
        public Cylinder(float r1, float r2, float h)
        {
            if(!initialized)
                Initialize();

            _r1 = r1;
            _r2 = r2;
            _h = h;

            for (uint idx = 0; idx < CALCS16; idx++)
                positionsCylinder[idx] = new Vertex();

            CalculatePositions();
        }

        public float R1
        {
            get { return _r1; }
            set 
            { 
                _r1 = value;
                CalculatePositions();
            }
        }

        public float R2
        {
            get { return _r2; }
            set
            {
                _r2 = value;
                CalculatePositions();
            }
        }

        public float H
        {
            get { return _h; }
            set
            {
                _h = value;
                CalculatePositions();
            }
        }
        private void Initialize()
        {
            initialized = true;

            const float calcAngle = (float)Math.PI / CALCS;
            const float calcAngleHalf = calcAngle / 2;

            for(uint idx = 0; idx < CALCS; idx++)
            {
                positionsUnitCircle[idx] = GlmNet.glm.cos(idx * calcAngle + calcAngleHalf);
            }

            for(uint idx = 0;idx < CALCS4; idx++)
            {
                uint idx3 = idx * 3;

                indices[idx3] = idx;
                indices[idx3 + 1] = (idx + 1) % CALCS4;
                indices[idx3 + 2] = idx + CALCS4;

                indices[idx3 + CALCS12] = (idx + 1) % CALCS4;
                indices[idx3 + CALCS12 + 1] = (idx + 1) % CALCS4 + CALCS4;
                indices[idx3 + CALCS12 + 2] = idx + CALCS4;

                indices[idx3 + CALCS24] = (idx + 1) % CALCS4 + CALCS8;
                indices[idx3 + CALCS24 + 1] = idx + CALCS8;
                indices[idx3 + CALCS24 + 2] = idx + CALCS12;

                indices[idx3 + CALCS36] = (idx + 1) % CALCS4 + CALCS12;
                indices[idx3 + CALCS36 + 1] = (idx + 1) % CALCS4 + CALCS8;
                indices[idx3 + CALCS36 + 2] = idx + CALCS12;

                indices[idx3 + CALCS48] = (idx + 1) % CALCS4;
                indices[idx3 + CALCS48 + 1] = idx;
                indices[idx3 + CALCS48 + 2] = idx + CALCS8;

                indices[idx3 + CALCS60] = (idx + 1) % CALCS4 + CALCS8;
                indices[idx3 + CALCS60 + 1] = (idx + 1) % CALCS4;
                indices[idx3 + CALCS60 + 2] = idx + CALCS8;

                indices[idx3 + CALCS72] = idx + CALCS4;
                indices[idx3 + CALCS72 + 1] = (idx + 1) % CALCS4 + CALCS4;
                indices[idx3 + CALCS72 + 2] = idx + CALCS12;

                indices[idx3 + CALCS84] = (idx + 1) % CALCS4 + CALCS4;
                indices[idx3 + CALCS84 + 1] = (idx + 1) % CALCS4 + CALCS12;
                indices[idx3 + CALCS84 + 2] = idx + CALCS12;
            }
        }

        private void CalculatePositions()
        {
            float hHalf = _h / 2;
            for (uint idx = 0; idx < CALCS; idx++)
            {
                float pos1R1 = positionsUnitCircle[idx] * _r1;
                float pos2R1 = positionsUnitCircle[CALCS - idx - 1] * _r1;
                float pos1R2 = positionsUnitCircle[idx] * _r2;
                float pos2R2 = positionsUnitCircle[CALCS - idx - 1] * _r2;

                positionsCylinder[idx].position = new vec3(pos1R1, pos2R1, -hHalf);
                positionsCylinder[idx + CALCS].position = new vec3(-pos2R1, pos1R1, -hHalf);
                positionsCylinder[idx + CALCS2].position = new vec3(-pos1R1, -pos2R1, -hHalf);
                positionsCylinder[idx + CALCS3].position = new vec3(pos2R1, -pos1R1, -hHalf);

                positionsCylinder[idx + CALCS4].position = new vec3(pos1R1, pos2R1, hHalf);
                positionsCylinder[idx + CALCS5].position = new vec3(-pos2R1, pos1R1, hHalf);
                positionsCylinder[idx + CALCS6].position = new vec3(-pos1R1, -pos2R1, hHalf);
                positionsCylinder[idx + CALCS7].position = new vec3(pos2R1, -pos1R1, hHalf);

                positionsCylinder[idx + CALCS8].position = new vec3(pos1R2, pos2R2, -hHalf);
                positionsCylinder[idx + CALCS9].position = new vec3(-pos2R2, pos1R2, -hHalf);
                positionsCylinder[idx + CALCS10].position = new vec3(-pos1R2, -pos2R2, -hHalf);
                positionsCylinder[idx + CALCS11].position = new vec3(pos2R2, -pos1R2, -hHalf);

                positionsCylinder[idx + CALCS12].position = new vec3(pos1R2, pos2R2, hHalf);
                positionsCylinder[idx + CALCS13].position = new vec3(-pos2R2, pos1R2, hHalf);
                positionsCylinder[idx + CALCS14].position = new vec3(-pos1R2, -pos2R2, hHalf);
                positionsCylinder[idx + CALCS15].position = new vec3(pos2R2, -pos1R2, -hHalf);
            }
        }
    }
}
